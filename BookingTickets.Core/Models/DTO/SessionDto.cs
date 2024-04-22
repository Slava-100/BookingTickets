using BookingTickets.Core.Models.Dtos;

namespace BookingTickets.Core.Models.DTO;

public class SessionDto : IdContainer
{
    public DateTime Time { get; set; }
    public decimal Price { get; set; }

    public Guid HallId { get; set; }
    public HallDto Hall { get; set; }

    public Guid FilmId { get; set; }
    public FilmDto Film { get; set; }

    public List<OrderPlaceDto> OrderPlaces { get; set; }
}