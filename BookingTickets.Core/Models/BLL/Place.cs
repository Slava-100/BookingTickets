namespace BookingTickets.Core.Models.BLL;

public class Place : IdContainer
{
    public int Number { get; set; }
    public int Row { get; set; }
    public bool IsBusy { get; set; }
}

