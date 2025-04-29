using Application.User;
using Domain.DTO;
using Domain.Entities;

namespace Application.Auth;

public class AuthService(IUserRepository<AppUser> userRepository) : IAuthService
{
    private readonly IUserRepository<AppUser> _userRepository = userRepository;
    
    public async Task<AuthResponse> RegisterAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthResponse> LoginAsync(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return AuthResponse.Failure("Username or password are required.");

        var user = await _userRepository.GetByUsernameOrEmailAsync(username);

        return new AuthResponse();
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