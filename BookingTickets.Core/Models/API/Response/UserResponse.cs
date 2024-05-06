using BookingTickets.Core.Enums;
using BookingTickets.Core.Models.DTO;

namespace BookingTickets.Core.Models.API.Response;

public class UserResponse : IdContainer
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public Position Position { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}

