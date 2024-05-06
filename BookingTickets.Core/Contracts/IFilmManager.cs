using BookingTickets.Core.Models.API;
using BookingTickets.Core.Models.BLL;
using BookingTickets.Core.Models.Dto;

namespace BookingTickets.Core.Contracts;

public interface IFilmManager
{
    Task<IEnumerable<Film>> GetFilmsAsync();
    Task<Guid> AddFilmAsync(Film film);
    Task UpdateFilmAsync(Film film);
    Task DeleteFilmAsync(Guid id);
    Task<Film> GetFilmByIdAsync(Guid id);
}

