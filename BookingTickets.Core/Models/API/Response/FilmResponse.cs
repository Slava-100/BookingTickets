namespace BookingTickets.Core.Models.API.Response;

public class FilmResponse : IdContainer
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
}
