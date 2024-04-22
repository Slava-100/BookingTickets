using BookingTickets.Core.Models.BLL;
using BookingTickets.Core.Models.Dtos;

namespace BookingTickets.Core.Contracts;

public interface IFilmManager
{
    Task<IEnumerable<Film>> GetFilmsAsync();
}

