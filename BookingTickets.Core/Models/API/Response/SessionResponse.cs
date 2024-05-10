using BookingTickets.Core.Models.DTO;
using BookingTickets.Core.Models.Dto;

namespace BookingTickets.Core.Models.API.Response;

public class SessionResponse : IdContainer
{
    public DateTime Time { get; set; }
    public decimal Price { get; set; }
    public FilmResponse Film { get; set; }
}

