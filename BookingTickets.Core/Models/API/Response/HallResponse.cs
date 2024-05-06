namespace BookingTickets.Core.Models.API.Response;

public class HallResponse : IdContainer
{
    public int Number { get; set; }
    public List<PlaceResponse> Places { get; set; }
}

