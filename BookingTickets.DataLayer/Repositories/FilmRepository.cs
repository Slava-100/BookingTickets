using BookingTickets.Core.Contracts;
using BookingTickets.Core.Models.Dtos;

namespace BookingTickets.DataLayer.Repositories;

public class FilmRepository(Context context) : BaseRepository<FilmDto>(context)
{
   
}

