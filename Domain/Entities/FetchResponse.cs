namespace Domain.Entities;

public class FetchResponse<T>
{
    public int TotalPages { get; set; }
    public int PageNumber { get; set; }
    public int TotalRecords { get; set; }
    public IEnumerable<T> Rows { get; set; } = [];
    public string Message { get; set; } = null!;
}