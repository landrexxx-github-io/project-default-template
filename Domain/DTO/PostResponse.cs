using System.Text.Json.Serialization;

namespace Domain.DTO;

public class PostResponse<T>
{
    [JsonPropertyName("rows_affected")]
    public int RowsAffected { get; set; }
    
    [JsonPropertyName("action")]
    public string Action { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    [JsonPropertyName("message")]
    public string Message { get; set; }
    
    [JsonPropertyName("data")]
    public T? Entity { get; set; }
}