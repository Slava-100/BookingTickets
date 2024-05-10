namespace BookingTickets.Core.Models.API.Response;

public class CinemaResponse : IdContainer
{
    public string Name { get; set; }
    public List<HallResponse> Halls { get; set; }
}

