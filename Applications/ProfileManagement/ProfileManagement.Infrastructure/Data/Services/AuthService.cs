
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProfileManagement.Application.Exceptions.Resources;
using ProfileManagement.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProfileManagement.Infrastructure.Data.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwtToken(string username, IEnumerable<Claim> additionalClaims = null)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings") ?? throw new InvalidOperationException(ExceptionMsg.EXC0002);
        var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
        };

        if (additionalClaims != null)
        {
            claims.AddRange(additionalClaims);
        }

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

