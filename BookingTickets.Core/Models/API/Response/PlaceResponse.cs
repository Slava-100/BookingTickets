using BookingTickets.Core.Models.DTO;

namespace BookingTickets.Core.Models.API.Response;

public class PlaceResponse : IdContainer
{
    public int Number { get; set; }
    public int Row { get; set; }
    public bool IsBusy { get; set; }
}

