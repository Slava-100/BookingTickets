using BookingTickets.Core.Models.DTO;

namespace BookingTickets.DataLayer.Repositories;

public class SessionRepository(Context context) : BaseRepository<SessionDto>(context)
{

}

