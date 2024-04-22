using BookingTickets.Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DataLayer.Repositories;

public class BaseRepository<TDto>(Context context) : IRepository<TDto> where TDto : class
{
    public async Task AddAsync(TDto entity)
    {
        await context.Set<TDto>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(TDto entity)
    {
        context.Set<TDto>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        return await context.Set<TDto>().ToListAsync();
    }

    public async Task<TDto> GetByIdAsync(int id)
    {
        return await context.Set<TDto>().FindAsync(id);
    }
}