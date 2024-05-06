using BookingTickets.Core.Models.DTO;

namespace BookingTickets.Core.Contracts;

public interface IUserRepository
{
    Task<UserDto?> GetUserByEmailAsync(string email);
}

