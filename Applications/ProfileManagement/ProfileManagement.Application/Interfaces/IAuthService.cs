using System.Security.Claims;

namespace ProfileManagement.Application.Interfaces;

public interface IAuthService
{
    public string GenerateJwtToken(string username, IEnumerable<Claim> additionalClaims = null);
}