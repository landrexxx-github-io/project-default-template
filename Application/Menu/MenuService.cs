using Domain.DTO;
using Domain.Entities;
using Domain.Helpers;

namespace Application.Menu;

public class MenuService(IGenericRepository<AppMenu> genericRepository) : IGenericService<AppMenu>
{
    private readonly IGenericRepository<AppMenu> _genericRepository = genericRepository;
    
    public async Task<FetchResponse<AppMenu>> GetAllAsync(string searchParam, int page = 1, int pageSize = 10)
    {
        return await _genericRepository.GetAllAsync(searchParam, page, pageSize);
    }

    public async Task<FetchResponse<AppMenu>> GetByIdAsync(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<PostResponse<AppMenu>> UpdSertAsync(AppMenu entity)
    {
        var tableRows = FilterPropertiesAndConvertToDataTable.ToDataTable([entity]);
        
        return await _genericRepository.UpdSertAsync(tableRows, entity);
    }

    public async Task<PostResponse<AppMenu>> DeleteAsync(params int[] id)
    {
        var tableRows = FilterPropertiesAndConvertToDataTable.ToDataTable(id);
        
        return await _genericRepository.DeleteAsync(tableRows);
    }

    public async Task<PostResponse<AppMenu>> DisableAsync(params int[] id)
    {
        var tableRows = FilterPropertiesAndConvertToDataTable.ToDataTable(id);

        return await _genericRepository.DisableAsync(tableRows);
    }
}