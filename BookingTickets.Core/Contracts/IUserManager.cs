using BookingTickets.Core.Models.API.Request;
using BookingTickets.Core.Models.API.Response;
using BookingTickets.Core.Models.BLL;

namespace BookingTickets.Core.Contracts;

public interface IUserManager
{
    Task<Guid> AddUserAsync(User user);
    Task<User> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task DeleteUserByIdAsync(Guid id);
    Task<AuthenticatedResponse> LoginUserAsync(LoginUserRequest request);
}

