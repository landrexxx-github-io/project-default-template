using Domain.DTO;

namespace Application.Auth;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(string username, string password);
    Task<AuthResponse> LoginAsync(string username, string password);
    Task<AuthResponse> RefreshTokenAsync(string token);
    Task<AuthResponse> RevokeTokenAsync(string token);
    Task<bool> IsUserInRoleAsync(int userId, int roleId);
}