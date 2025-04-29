using System.Security.Claims;
using Domain.Entities;

namespace Infrastructure.Auth;

public interface IJwtService
{
    string GenerateToken(AppUser user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    
}