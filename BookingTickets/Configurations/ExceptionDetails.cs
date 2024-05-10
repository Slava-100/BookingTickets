namespace BookingTickets.Configurations;
public class ExceptionDetails(string message, int code)
{
    public int Code { get; set; } = code;
    public string Message { get; set; } = message;
}

