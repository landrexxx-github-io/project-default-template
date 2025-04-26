using Domain.DTO;

namespace Application.User;

public interface IUserRepository<T>
{
    Task<FetchResponse<T>> GetByEmailAsync();
    Task<FetchResponse<T>> GetByUserNameAsync();
    Task<PostResponse<T>> UpdatePasswordAsync(int userId, string newPassword);
}