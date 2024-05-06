using AutoMapper;
using BookingTickets.Business.Validations;
using BookingTickets.Core.Contracts;
using BookingTickets.Core.Exceptions;
using BookingTickets.Core.Models.API.Request;
using BookingTickets.Core.Models.API.Response;
using BookingTickets.Core.Models.BLL;
using BookingTickets.Core.Models.DTO;
using Serilog;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookingTickets.Business.Managers;
public class UserManager(IRepository<UserDto> baseRepository, IUserRepository userRepository, IMapper mapper, UserValidator userValidator, Secrets secret, ITokenManager tokenManager) : InstructionsForHashPassword, IUserManager
{
    private readonly Serilog.ILogger _logger = Log.ForContext<UserManager>();
    public async Task<User> GetUserByIdAsync(Guid id)
    {
        _logger.Information($"Обращаемся к методу репозитория получение пользователя по id {id}");
        var user = await baseRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException($"Пользователь с id {id} не найден");
        var userResponse = mapper.Map<User>(user);

        return userResponse;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        _logger.Information("Обращаемся к методу репозитория Получение всех пользователей");
        var callback = await baseRepository.GetAllAsync();
        var users = mapper.Map<IEnumerable<User>>(callback);

        return users;
    }

    public async Task DeleteUserByIdAsync(Guid id)
    {
        _logger.Information($"Проверяем существует ли пользователь с id {id}");
        var user = await baseRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException($"Пользователь с id {id} не найден");

        _logger.Information($"Обращаемся к методу репозитория удаление пользователя по id {id}");
        await baseRepository.DeleteAsync(user);
    }

    public async Task<AuthenticatedResponse> LoginUserAsync(LoginUserRequest request)
    {
        _logger.Information("Проверяем переданы ли данные");
        if (string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.Email))
            throw new BadRequestException($"{request.Password} и/или {request.Password} пусты");

        _logger.Information("Проверяем есть ли такой пользователь в базе данных по email");
        var user = await userRepository.GetUserByEmailAsync(request.Email) ?? throw new NotAuthorizedException("Не пройдена аутентификация");

        _logger.Information("Проверка данных аутентификации");
        var checkPassword = VerifyPassword(request.Password, user.Password, Convert.FromHexString(user.Salt));
        
        if (!checkPassword)
            throw new NotAuthorizedException("Аутентификация не пройдена");

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.FullName),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Position.ToString()),
        };

        var accessToken = await tokenManager.GenerateAccessTokenAsync(claims);

        return new AuthenticatedResponse { Token = accessToken };
    }

    public async Task<Guid> AddUserAsync(User user)
    {
        var validationResult = await userValidator.ValidateAsync(user);

        if (!validationResult.IsValid)
        {
            var errorMessage = "";

            foreach (var error in validationResult.Errors)
                errorMessage += error.ErrorMessage;

            _logger.Debug(errorMessage);
            throw new InvalidEmailFormatException(errorMessage);
        }

        if (await userRepository.GetUserByEmailAsync(user.Email) is not null)
            throw new ("Такой Email уже существует");

        user.Password = HashPasword(user.Password, out var salt);
        user.Salt = Convert.ToHexString(salt);

        _logger.Information("Обращаемся к методу репозитория Создание нового пользователя");
        var userDto = await baseRepository.AddAsync(mapper.Map<UserDto>(user));
        _logger.Information($"Создан новый пользователь с id {userDto.Id}");

        return userDto.Id;
    }

    private string HashPasword(string password, out byte[] salt)
    {
        password = $"{password}{secret.PasswordSecret}";
        salt = RandomNumberGenerator.GetBytes(keySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iterations,
            hashAlgorithm,
            keySize);
        return Convert.ToHexString(hash);
    }

    public bool VerifyPassword(string password, string hash, byte[] salt)
    {
        password = $"{password}{secret.PasswordSecret}";
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);

        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }
}
