using BookingTickets.Core.Enums;

namespace BookingTickets.Core.Models.DTO;

public class UserDto : IdContainer
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