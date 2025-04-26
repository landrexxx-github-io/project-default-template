using System.Text.Json.Serialization;

namespace Domain.Entities;

public class UserAccount
{
    [JsonPropertyName("user_account_id")]
    public int UserAccountId { get; set; }
    
    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;
    
    [JsonPropertyName("password")]
    public string Password { get; set; } = null!;
    
    [JsonPropertyName("app_role_id")]
    public int AppRoleId { get; set; }
    
    [JsonPropertyName("is_active")]
    public string IsActive { get; set; } = "Y";
    
}