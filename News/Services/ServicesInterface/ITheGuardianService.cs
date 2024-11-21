namespace News.Services.ServicesInterface;

public interface ITheGuardianService
{
    Task<string> GetDataAsync(string url);
}