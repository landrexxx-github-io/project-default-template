using Domain.DTO;

namespace Application;

public interface IGenericService<T>
{
    Task<FetchResponse<T>> GetAllAsync(string searchParam, int page = 1, int pageSize = 10);
    Task<FetchResponse<T>> GetByIdAsync(int id);
    Task<PostResponse<T>> UpdSertAsync(T entity);
    Task<PostResponse<T>> DeleteAsync(params int[] id); // permanently delete
    Task<PostResponse<T>> DisableAsync(params int[] id); // temporary delete
}