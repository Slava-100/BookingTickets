
namespace BookingTickets.Core.Models.DTO;

public class CinemaDto : IdContainer
{
    public string Name { get; set; }
    public List<HallDto> Halls { get; set; }
    public List<UserDto> Users { get; set; }
}

