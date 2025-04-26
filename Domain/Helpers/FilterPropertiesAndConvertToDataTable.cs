using System.Data;
using Domain.Attributes;
using FastMember;

namespace Domain.Helpers;

public static class FilterPropertiesAndConvertToDataTable
{
    public static DataTable ToDataTable<T>(IEnumerable<T>? list)
    {
        var table = new DataTable();
        
        if (list == null) return table;
        
        // filter only the properties that are included
        var includedProperties = typeof(T).GetProperties()
            .Where(p => !Attribute.IsDefined(p, typeof(ExcludedFromDataTableAttribute)))
            .Select(p => p.Name)
            .ToArray();
        
        using var reader = ObjectReader.Create(list, includedProperties);
        
        table.Load(reader);
        
        return table;
    }
    
    public static DataTable ToDataTable(int[] ids)
    {
        var table = new DataTable();
        
        if (ids.Length == 0) return table;
        
        using var reader = ObjectReader.Create(ids);
        
        table.Load(reader);
        
        return table;
    }
}