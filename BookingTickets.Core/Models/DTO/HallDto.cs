

namespace BookingTickets.Core.Models.DTO;

public class HallDto : IdContainer
{
    public int Number { get; set; }
    public Guid CinemaId { get; set; }
    public CinemaDto Cinema { get; set; }

    public List<SessionDto> Sessions { get; set; }

    public List<PlaceDto> Places { get; set; }
}

