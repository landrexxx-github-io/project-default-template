using Domain.DTO;

namespace Application.User;

public interface IUserRepository<T>
{
    Task<FetchResponse<T>> GetByUsernameOrEmailAsync(string usernameOrEmail);
    Task<PostResponse<T>> UpdatePasswordAsync(int userId, string newPassword);
}