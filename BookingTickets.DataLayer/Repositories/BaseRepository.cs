using BookingTickets.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace BookingTickets.DataLayer.Repositories;

public class BaseRepository<TDto>(Context context) : IRepository<TDto> where TDto : class
{
    private readonly Serilog.ILogger _logger = Log.ForContext<BaseRepository<TDto>>();
    public async Task<TDto> AddAsync(TDto entity)
    {
        await context.Set<TDto>().AddAsync(entity);
        await context.SaveChangesAsync();
        _logger.Information($"{typeof(TDto)} добавлен в базу");

        return entity;
    }
    public async Task UpdateAsync(TDto entity)
    {
        context.Set<TDto>().Update(entity);
        await context.SaveChangesAsync();

        _logger.Information($"{typeof(TDto)} обновлён");
    }
    public async Task DeleteAsync(TDto entity)
    {
        context.Set<TDto>().Remove(entity);
        await context.SaveChangesAsync();

        _logger.Information($"{typeof(TDto)} удалён");
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        _logger.Information($"достаём всех {typeof(TDto)}");
        return await context.Set<TDto>().ToListAsync();
    }

    public async Task<TDto?> GetByIdAsync(Guid id)
    {
        _logger.Information($"достаём всех {typeof(TDto)}");
        return await context.Set<TDto>().FindAsync(id);
    }
    public async Task<IEnumerable<TDto>> GetAllWithIncludesAsync(List<Expression<Func<TDto, object>>> includeProperties)
    {
        IQueryable<TDto> query = context.Set<TDto>();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        _logger.Information($"достаём всех {typeof(TDto)}");
        
        return await query.ToListAsync();
    }
}
