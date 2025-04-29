namespace Domain.Entities;

public class RefreshToken
{
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public bool IsExpired => DateTime.UtcNow > Expires;
    public DateTime CreatedDate { get; set; }
    public DateTime? RevokedDate { get; set; }
    public string ReplacedByToken { get; set; }
    public bool IsActive => RevokedDate == null && !IsExpired;
}