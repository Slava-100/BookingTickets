using BookingTickets.Core.Models.DTO;

namespace BookingTickets.Core.Models.API.Response;

public class OrderPlaceResponse : IdContainer
{
    public SessionResponse Session { get; set; }
    public PlaceResponse Place { get; set; }
    public OrderResponse Order { get; set; }
}

