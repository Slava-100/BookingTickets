using System.Security.Claims;

namespace BookingTickets.Core.Contracts;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);
}

