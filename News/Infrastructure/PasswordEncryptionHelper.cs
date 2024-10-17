using System.Security.Cryptography;
using News.Infrastructure.IInfrastructure;

namespace News.Infrastructure;

internal class PasswordEncryptionHelper : IPasswordEncryptionHelper
{
    private const short SaltByteSize = 16;
    private const short HashByteSize = 20;

    public byte[] GenerateSalt(string password)
    {
        byte[] salt = new byte[SaltByteSize];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return salt;
    }

    public string HashPassword(string password, byte[] salt)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
        byte[] hash = pbkdf2.GetBytes(HashByteSize);
        byte[] hashBytes = new byte[HashByteSize + SaltByteSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltByteSize);
        Array.Copy(hash, 0, hashBytes, SaltByteSize, HashByteSize);

        return Convert.ToBase64String(hashBytes);
    }

    public bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hasedPassword = HashPassword(password, salt);

        return hasedPassword == hash;
    }
}