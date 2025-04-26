using System.Text.Json.Serialization;

namespace Domain.Entities;

public class AppRole
{
    [JsonPropertyName("role_id")]
    public int RoleId { get; set; }
    
    [JsonPropertyName("role_name")]
    public string RoleName { get; set; } = null!;
    
    [JsonPropertyName("is_active")]
    public string IsActive { get; set; } = "Y";
}