using BookingTickets.Core.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingTickets.Business.Managers;

public class TokenManager(Secrets secret) : ITokenManager
{
    public Task<string> GenerateAccessTokenAsync(IEnumerable<Claim> claims)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret.TokenSecret));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512);

        var tokenOptions = new JwtSecurityToken(
            issuer: "BookingTickets",
            audience: "UI",
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: signinCredentials
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return Task.FromResult(tokenString);
    }
}

