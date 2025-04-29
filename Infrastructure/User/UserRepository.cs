using System.Data;
using Application;
using Application.User;
using Dapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Infrastructure.User;

public class UserRepository<T>(ConfigContext configContext) : IGenericRepository<T>, IUserRepository<T> 
{
    private readonly ConfigContext _configContext = configContext;
    
    public async Task<FetchResponse<T>> GetByUsernameOrEmailAsync(string usernameOrEmail)
    {
        await using var connection = new SqlConnection(_configContext.ConnectionString);
        
        await connection.OpenAsync();
        
        const string storedProcedure = "GetUserByUsernameOrEmail";
        var parameters = new
        {
            UsernameOrEmail = usernameOrEmail,
        };

        var results = await connection.QueryAsync<T>(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return new FetchResponse<T>();
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