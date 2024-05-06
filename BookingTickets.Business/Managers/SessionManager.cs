using AutoMapper;
using BookingTickets.Core.Contracts;
using BookingTickets.Core.Models.BLL;
using BookingTickets.Core.Models.DTO;
using Serilog;

namespace BookingTickets.Business.Managers;
public class SessionManager(IRepository<SessionDto> baseRepository, IMapper mapper) : ISessionManager
{
    private readonly Serilog.ILogger _logger = Log.ForContext<SessionManager>();

    public async Task<List<Session>> GetSessionsByFilmIdAsync(Guid id, DateTime? dateTime)
    {
        if (!dateTime.HasValue)
        {
            dateTime = DateTime.Now;
        }
        
        _logger.Information("Обращаемся к методу репозитория получения всех сеансов с внутренними зависимостями");
        IEnumerable<SessionDto> callback = await baseRepository.GetAllWithIncludesAsync([s => s.Hall, s => s.Film]);
        var sessionByFilm = callback.Where(x => x.FilmId == id && x.Time > dateTime);

        return mapper.Map<List<Session>>(sessionByFilm);
    }
}
