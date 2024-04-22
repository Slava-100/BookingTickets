namespace BookingTickets.Core.Models.DTO;

public class PlaceDto : IdContainer
{
    public int Number { get; set; }
    public int Row { get; set; }

    public Guid HallId { get; set; }
    public HallDto Hall { get; set; }

    public List<OrderPlaceDto> OrderPlaces { get; set; }
}