using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Auth;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        var hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashBytes);
    }

    public bool VerifyPassword(string hashedPassword, string password)
    {
        var hashedProvidedPassword = HashPassword(password);
        return hashedProvidedPassword == hashedPassword;
    }
}