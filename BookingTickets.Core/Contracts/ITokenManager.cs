using System.Security.Claims;

namespace BookingTickets.Core.Contracts;

public interface ITokenManager
{
    Task<string> GenerateAccessTokenAsync(IEnumerable<Claim> claims);
}

