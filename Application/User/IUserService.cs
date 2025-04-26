using Domain.DTO;
using Domain.Entities;

namespace Application.User;

public interface IUserService<T>
{
    Task<FetchResponse<T>> GetByEmailAsync();
    Task<FetchResponse<T>> GetByUserNameAsync();
    Task<PostResponse<T>> UpdatePasswordAsync(int userId, string newPassword);
}