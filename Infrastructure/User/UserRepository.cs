using System.Data;
using Application;
using Application.User;
using Domain.DTO;
using Domain.Entities;

namespace Infrastructure.User;

public class UserRepository<T> : IGenericRepository<T>, IUserRepository<T> 
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

    public async Task<FetchResponse<AppMenu>> GetAllAsync(string searchParam, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public async Task<FetchResponse<T>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<PostResponse<T>> UpdSertAsync(DataTable dt, T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<PostResponse<T>> DeleteAsync(DataTable dt)
    {
        throw new NotImplementedException();
    }

    public async Task<PostResponse<T>> DisableAsync(DataTable dt)
    {
        throw new NotImplementedException();
    }
}