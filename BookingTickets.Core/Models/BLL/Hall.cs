
namespace BookingTickets.Core.Models.BLL;
public class Hall : IdContainer
{
    public int Number { get; set; }
    public List<Place> Places { get; set; }
}

