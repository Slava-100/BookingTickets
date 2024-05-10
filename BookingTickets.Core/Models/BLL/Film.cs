

namespace BookingTickets.Core.Models.BLL;

public class Film : IdContainer
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
}
