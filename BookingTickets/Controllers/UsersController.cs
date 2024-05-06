using AutoMapper;
using BookingTickets.Core.Contracts;
using BookingTickets.Core.Models.API.Request;
using BookingTickets.Core.Models.API.Response;
using BookingTickets.Core.Models.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BookingTickets.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserManager usersManager, IMapper mapper) : Controller
{
    private readonly Serilog.ILogger _logger = Log.ForContext<UsersController>();

    [Authorize(Roles = "AdminSystem")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsersAsync()
    {
        _logger.Information($"Получаем всех пользователей");
        var users = await usersManager.GetAllUsersAsync();

        return Ok(mapper.Map<IEnumerable<UserResponse>>(users));
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetUserById([FromRoute] Guid id)
    {
        _logger.Information($"Получаем пользователя по id {id}");
        var user = await usersManager.GetUserByIdAsync(id);

        return Ok(mapper.Map<UserResponse>(user));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserRequest request)
    {
        _logger.Information($"{request.FullName} {request.Password}");
        var id = await usersManager.AddUserAsync(mapper.Map<User>(request));

        return Ok(id);
    }

    [Authorize(Roles = "AdminSystem")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUserByIdAsync(Guid id)
    {
        _logger.Information($"Удаляем пользователя с id {id}");
        await usersManager.DeleteUserByIdAsync(id);

        return NoContent();
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticatedResponse>> LoginAsync([FromBody] LoginUserRequest request)
    {
        _logger.Information($"Аутентификация пользователя");
        var authenticatedResponse = await usersManager.LoginUserAsync(request);

        return Ok(authenticatedResponse);
    }
}