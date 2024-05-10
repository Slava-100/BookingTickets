
namespace BookingTickets.Core.Models.API.Request;

public class SessionRequest
{
    public DateTime Time { get; set; }
    public decimal Price { get; set; }
    public Guid HallId { get; set; }
    public Guid FilmId { get; set; }
}

