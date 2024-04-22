
namespace BookingTickets.Core.Contracts;

public interface IRepository<TDto>
{
    Task AddAsync(TDto entity);
    Task RemoveAsync(TDto entity);
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto> GetByIdAsync(int id);
}

