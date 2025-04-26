using System.Data;
using Application;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Menu;

public class MenuRepository(ConfigContext configContext) : IGenericRepository<AppMenu>
{
    private readonly ConfigContext _configContext = configContext;
    
    public async Task<FetchResponse<AppMenu>> GetAllAsync(string searchParam, int page = 1, int pageSize = 10)
    {
        await using var conn = new SqlConnection(_configContext.ConnectionString);
        
        await conn.OpenAsync();
        
        const string storedProcedure = "";

        var parameters = new
        {
            UserId = _configContext.UserId,
        };

        var results = await conn.QueryAsync<AppMenu>(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );
        
        await conn.CloseAsync();

        var appMenus = results as AppMenu[] ?? results.ToArray();
        
        var firstRow = appMenus.FirstOrDefault();
        var rows = appMenus.ToList();

        return new FetchResponse<AppMenu>
        {
            Rows = rows!,
            TotalPages = firstRow?.TotalPages ?? 0,
            TotalRecords = firstRow?.TotalRecords ?? 0,
            PageNumber = page,
            Message = rows!.Count > 0 ? "Success" : "Failure"
        };
    }

    public async Task<FetchResponse<AppMenu>> GetByIdAsync(int id)
    {
        await using var conn = new SqlConnection(_configContext.ConnectionString);
        
        await conn.OpenAsync();
        
        const string storedProcedure = "";

        var parameters = new
        {
            MenuId = id,
        };

        var results = await conn.QueryFirstOrDefaultAsync<AppMenu>(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );
        
        await conn.CloseAsync();
        
        return new FetchResponse<AppMenu>
        {
            Rows = [results!],
            TotalPages = 1,
            TotalRecords = 1,
            PageNumber = 1,
            Message = results != null ? "Success" : "Failure"
        };
    }

    public async Task<PostResponse<AppMenu>> UpdSertAsync(DataTable dt, AppMenu entity)
    {
        await using var conn = new SqlConnection(_configContext.ConnectionString);
        
        await conn.OpenAsync();
        
        const string storedProcedure = "";

        var parameters = new
        {
            Tt = dt.AsTableValuedParameter("dbo.Menu_tt"),
            UserId = _configContext.UserId,
        };

        var rowsAffected = await conn.ExecuteAsync(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return new PostResponse<AppMenu>
        {
            RowsAffected = rowsAffected,
            Action = entity.MenuId is null ? ActionType.Create.ToString() : ActionType.Update.ToString(),
            Message = rowsAffected > 0 ? "Success" : "Failed",
            Entity = entity
        };
    }

    public async Task<PostResponse<AppMenu>> DeleteAsync(DataTable dt)
    {
        await using var conn = new SqlConnection(_configContext.ConnectionString);
        
        await conn.OpenAsync();
        
        const string storedProcedure = "";

        var parameters = new
        {
            Tt = dt.AsTableValuedParameter("dbo.TableId_tt"),
            UserId = _configContext.UserId,
        };

        var rowsAffected = await conn.ExecuteAsync(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return new PostResponse<AppMenu>
        {
            RowsAffected = rowsAffected,
            Action = ActionType.Delete.ToString(),
            Message = rowsAffected > 0 ? "Success" : "Failed",
        };
    }

    public async Task<PostResponse<AppMenu>> DisableAsync(DataTable dt)
    {
        await using var conn = new SqlConnection(_configContext.ConnectionString);

        await conn.OpenAsync();

        const string storedProcedure = "";

        var parameters = new
        {
            Tt = dt.AsTableValuedParameter("dbo.TableId_tt"),
            UserId = _configContext.UserId,
        };

        var rowsAffected = await conn.ExecuteAsync(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return new PostResponse<AppMenu>
        {
            RowsAffected = rowsAffected,
            Action = ActionType.Disable.ToString(),
            Message = rowsAffected > 0 ? "Success" : "Failed",
        };
    }
}