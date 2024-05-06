using BookingTickets.Core.Enums;
using BookingTickets.Core.Models.DTO;

namespace BookingTickets.Core.Models.BLL;

public class User : IdContainer
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public Position Position { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string? Phone { get; set; }

    public Guid? CinemaId { get; set; }
    public CinemaDto? Cinema { get; set; }

    public List<OrderDto>? Orders { get; set; }
}

