using Domain.DTO;
using Domain.Entities;

namespace Application.User;

public class UserService<T> : IUserService<T>
{
    public async Task<FetchResponse<T>> GetByEmailAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<FetchResponse<T>> GetByUserNameAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<PostResponse<T>> UpdatePasswordAsync(int userId, string newPassword)
    {
        throw new NotImplementedException();
    }
}