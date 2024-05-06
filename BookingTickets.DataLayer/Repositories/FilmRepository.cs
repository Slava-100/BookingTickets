using BookingTickets.Core.Models.Dto;

namespace BookingTickets.DataLayer.Repositories;

public class FilmRepository(Context context) : BaseRepository<FilmDto>(context)
{
   
}

