namespace Infrastructure.Auth;

public class JwtSettings
{
    public string Secret { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public TimeSpan AccessTokenLifetime { get; set; }
    public int RefreshTokenTTL { get; set; }
}