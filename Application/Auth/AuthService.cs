using Domain.DTO;

namespace Application.Auth;

public class AuthService : IAuthService
{
    public async Task<AuthResponse> RegisterAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthResponse> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthResponse> RefreshTokenAsync(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthResponse> RevokeTokenAsync(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsUserInRoleAsync(int userId, int roleId)
    {
        throw new NotImplementedException();
    }
}