using System.Data;
using Domain.Entities;

namespace Application;

public interface IGenericRepository<T>
{
    Task<FetchResponse<T>> GetAllAsync(string searchParam, int page = 1, int pageSize = 10);
    Task<FetchResponse<T>> GetByIdAsync(int id);
    Task<PostResponse<T>> UpdSertAsync(DataTable dt, T entity);
    Task<PostResponse<T>> DeleteAsync(DataTable dt);
    Task<PostResponse<T>> DisableAsync(DataTable dt);
}