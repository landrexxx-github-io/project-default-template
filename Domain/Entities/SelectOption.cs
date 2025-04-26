using System.Text.Json.Serialization;

namespace Domain.Entities;

public class SelectOption
{
    [JsonPropertyName("value")]
    public string Value { get; set; } = null!;
    
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;
}