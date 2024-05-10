
namespace BookingTickets.Core.Models.BLL;
public class Session : IdContainer
{
    public DateTime Time { get; set; }
    public decimal Price { get; set; }
    public Hall Hall { get; set; }
    public Film Film { get; set; }
}

