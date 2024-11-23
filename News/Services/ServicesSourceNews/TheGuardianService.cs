using Microsoft.Extensions.Options;
using News.Entities.ModelsSourceNewsApi;
using News.Services.ServicesInterface;
using System.Text.Json;

namespace News.Services.ServicesSourceNews;

public class TheGuardianService : ITheGuardianService
{
    private readonly HttpClient _client;
    private readonly SourceNewsApiConfigModel _config;
    private readonly string _apiKey;

    public TheGuardianService(IHttpClientFactory client, IOptions<SourceNewsApiConfigModel> config)
    {
        _config = config.Value;
        _apiKey = "api-key=" + _config.TheGuardian;
        _client = client.CreateClient();
        _client.BaseAddress = new Uri("https://content.guardianapis.com/");
    }

    public async Task<TheGuardianModel> GetAllArticlesAsync()
    {
        string url = $"search?{_apiKey}";
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var result = JsonSerializer.Deserialize<TheGuardianModel>(jsonString, options);

        return result;
    }

    public async Task<TheGuardianArticleModel> GetSignleAsync(string id)
    {
        string url = $"{id}?{_apiKey}&show-fields=all";
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        var result = JsonSerializer.Deserialize<TheGuardianArticleModel>(jsonString, options);

        return result;
    }
}