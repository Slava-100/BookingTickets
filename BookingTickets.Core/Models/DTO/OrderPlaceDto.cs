namespace BookingTickets.Core.Models.DTO;

public class OrderPlaceDto : IdContainer
{
    public Guid SessionId { get; set; }
    public SessionDto Session { get; set; }

    public Guid PlaceId { get; set; }
    public PlaceDto Place { get; set; }

    public Guid OrderId { get; set; }
    public OrderDto Order { get; set; }
}