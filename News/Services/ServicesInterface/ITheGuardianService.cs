namespace News.Services.ServicesInterface;

public interface ITheGuardianService
{
    Task<string> GetAllArticlesAsync();

    Task<string> GetSignleAsync(string id);
}