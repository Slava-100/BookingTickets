namespace BookingTickets.Core.Models.API.Request;

public class FilmRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }

}

