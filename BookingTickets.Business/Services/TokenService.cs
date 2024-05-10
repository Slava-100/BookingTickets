using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookingTickets.Core.Contracts;
using Microsoft.IdentityModel.Tokens;

namespace BookingTickets.Business.Services;

public class TokenService(Secrets secret) : ITokenService
{
    public string GenerateAccessToken(IEnumerable<Claim> claims)
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

        return tokenString;
    }
}

