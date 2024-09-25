using News.Entities.Models;

namespace News.Infrastructure;

public interface IPasswordEncryptionHelper
{
    public byte[] GenerateSalt(string password);

    public string HashPassword(string password, byte[] salt);

}