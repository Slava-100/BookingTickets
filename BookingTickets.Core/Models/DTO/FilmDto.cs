using BookingTickets.Core.Models.DTO;

namespace BookingTickets.Core.Models.Dtos;

public class FilmDto : IdContainer
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
    public List<SessionDto> Sessions { get; set; }
}

