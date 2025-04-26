namespace Domain.DTO;

public class AuthResponse
{
    public bool Success { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime TokenExpiration { get; set; }
    public IEnumerable<string> Errors { get; set; }
}