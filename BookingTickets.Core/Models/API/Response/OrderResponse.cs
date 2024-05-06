using BookingTickets.Core.Enums;
using BookingTickets.Core.Models.DTO;

namespace BookingTickets.Core.Models.API.Response;

public class OrderResponse : IdContainer
{
    public string Code { get; set; }
    public OrderStatus Status { get; set; }
    public UserResponse User { get; set; }
    public List<OrderPlaceResponse> OrderPlaces { get; set; }
}

