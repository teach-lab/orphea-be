using Microsoft.Extensions.Options;
using News.Entities.ModelsSourceNewsApi;
using News.Services.ServicesInterface;
using System.Text.Json;

namespace News.Services.ServicesSourceNews;

public class TheGuardianService : ITheGuardianService
{
    private readonly HttpClient _httpClient;
    private readonly SourceNewsApiConfigModel _config;
    private readonly string _apiKey;

    public TheGuardianService(
        HttpClient httpClient,
        IOptions<SourceNewsApiConfigModel> config)
    {
        _config = config.Value;
        _apiKey = "api-key=" + _config.TheGuardian.APIKey;
        _httpClient = httpClient;
    }

    public async Task<TheGuardianModel> GetAllAsync(CancellationToken cancellationToken)
    {
        string url = $"search?{_apiKey}";

        var response = await _httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var result = JsonSerializer.Deserialize<TheGuardianModel>(jsonString, options);

        return result;
    }

    public async Task<TheGuardianArticleModel> GetAsync(string id, CancellationToken cancellationToken)
    {
        string decodedId = Uri.UnescapeDataString(id);

        string url = $"{decodedId}?{_apiKey}&show-fields=all";
        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        var result = JsonSerializer.Deserialize<TheGuardianArticleModel>(jsonString, options);

        return result;
    }
}