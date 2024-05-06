using BookingTickets.Core.Contracts;
using BookingTickets.Core.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BookingTickets.DataLayer.Repositories;

public class UserRepository(Context context) : BaseRepository<UserDto>(context), IUserRepository
{
    private readonly Serilog.ILogger _logger = Log.ForContext<UserRepository>();
    public async Task<UserDto?> GetUserByEmailAsync(string email)
    {
        _logger.Information("Идём в базу данных и ищем пользователя по почте {email}", email);

        return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
