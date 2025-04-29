namespace Domain.DTO;

public class AuthResponse
{
    public bool Success { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime TokenExpiration { get; set; }
    public IEnumerable<string> Errors { get; set; }
    public static AuthResponse SuccessResult(string accessToken, string refreshToken, DateTime expiration)
        => new() { Success = true, Token = accessToken, RefreshToken = refreshToken, TokenExpiration = expiration };

    public static AuthResponse Failure(params string[] errors)
        => new() { Success = false, Errors = errors };
}