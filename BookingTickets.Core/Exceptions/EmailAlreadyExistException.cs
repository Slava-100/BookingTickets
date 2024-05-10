namespace BookingTickets.Core.Exceptions;

public class EmailAlreadyExistException(string message) : Exception(message);