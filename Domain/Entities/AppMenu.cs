using System.Text.Json.Serialization;
using Domain.Attributes;

namespace Domain.Entities;

public class AppMenu
{
    [JsonPropertyName("menu_id")]
    public int? MenuId { get; set; }
    
    [JsonPropertyName("parent_menu_id")]
    public int ParentMenuId { get; set; }
    
    [JsonPropertyName("menu_name")]
    public string MenuName { get; set; } = null!;
    
    [JsonPropertyName("menu_icon")]
    public string MenuIcon { get; set; } = null!;
    
    [JsonPropertyName("menu_url")]
    [ExcludedFromDataTable]
    public string MenuUrl { get; set; } = null!;
    
    [JsonPropertyName("is_active")]
    public string IsActive { get; set; } = null!;
    
    [JsonPropertyName("seq_no")]
    public string SeqNo { get; set; } = null!;

    [ExcludedFromDataTable]
    public int TotalRecords { get; set; }
    
    [ExcludedFromDataTable]
    public int TotalPages { get; set; }
}