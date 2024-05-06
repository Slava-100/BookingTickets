
using System.Linq.Expressions;

namespace BookingTickets.Core.Contracts;

public interface IRepository<TDto>
{
    Task<TDto> AddAsync(TDto entity);
    Task UpdateAsync(TDto entity);
    Task DeleteAsync(TDto entity);
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<TDto>> GetAllWithIncludesAsync(List<Expression<Func<TDto, object>>> includeProperties);
}

