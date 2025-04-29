using System.Text.Json.Serialization;

namespace Domain.DTO;

public class FetchResponse<T>
{
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    
    [JsonPropertyName("page_number")]
    public int PageNumber { get; set; }
    
    [JsonPropertyName("total_records")]
    public int TotalRecords { get; set; }
    
    [JsonPropertyName("rows")]
    public IEnumerable<T> Rows { get; set; } = [];

    [JsonPropertyName("message")] 
    public string Message { get; set; }
}