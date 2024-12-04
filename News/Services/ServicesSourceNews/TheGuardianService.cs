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

    public TheGuardianService(
        IHttpClientFactory clientFactory,
        IOptions<SourceNewsApiConfigModel> config)
    {
        _config = config.Value;
        _apiKey = "api-key=" + _config.TheGuardian.APIKey;
        _client = clientFactory.CreateClient(nameof(TheGuardianService));
    }

    public async Task<TheGuardianModel> GetAllAsync(CancellationToken cancellationToken)
    {
        string url = $"{_config.TheGuardian.BaseUrl}search?{_apiKey}";

        var response = await _client.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var result = JsonSerializer.Deserialize<TheGuardianModel>(jsonString, options);

        return result;
    }

    public async Task<TheGuardianArticleModel> GetAsync(string id, CancellationToken cancellationToken)
    {
        string decodedId = Uri.UnescapeDataString(id);
        string url = $"{_config.TheGuardian.BaseUrl}{decodedId}?{_apiKey}&show-fields=all";
        var response = await _client.GetAsync(url, cancellationToken);

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