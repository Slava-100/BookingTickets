namespace BookingTickets.Core.Exceptions;

public class NotAuthorizedException(string message) : Exception(message);
