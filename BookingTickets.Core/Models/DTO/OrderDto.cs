
using BookingTickets.Core.Enums;

namespace BookingTickets.Core.Models.DTO;

public class OrderDto : IdContainer
{
    public string Code { get; set; }
    public OrderStatus Status { get; set; }
    public Guid UserId { get; set; }
    public UserDto User { get; set; }

    public List<OrderPlaceDto> OrderPlaces { get; set; }
}

