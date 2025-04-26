using Domain.Entities;

namespace Application.Auth;

public interface ILoginService<T>
{
    Task<FetchResponse<T>> GetUserByUsernameAsync(string username);
    Task<string> GenerateJwtTokenAsync(UserAccount user);
}