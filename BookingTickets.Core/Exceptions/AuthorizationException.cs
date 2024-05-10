namespace BookingTickets.Core.Exceptions;

public class AuthorizationException(string message) : Exception(message);
