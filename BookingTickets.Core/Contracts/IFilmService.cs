using BookingTickets.Core.Models.BLL;

namespace BookingTickets.Core.Contracts;

public interface IFilmService
{
    Task<IEnumerable<Film>> GetFilmsAsync();
    Task<Guid> AddFilmAsync(Film film);
    Task UpdateFilmAsync(Film film);
    Task DeleteFilmAsync(Guid id);
    Task<Film> GetFilmByIdAsync(Guid id);
}

