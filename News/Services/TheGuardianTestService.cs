using News.Services.ServicesInterface;

namespace News.Services;

public class TheGuardianTestService : ITheGuardianService
{
    private readonly HttpClient _httpClient;

    public TheGuardianTestService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetDataAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}