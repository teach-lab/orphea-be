using Microsoft.Extensions.Options;
using News.GptModels;
using News.Infrastructure;
using News.Services.ServicesInterface;
using Newtonsoft.Json;
using System.Text;

namespace News.Services;

public class AiIntegrationService : IAiIntegrationService
{
    private readonly OpenAiOptions _options;
    private readonly HttpClient _client;

    public AiIntegrationService(IOptions<OpenAiOptions> options)
    {
        _options = options.Value;
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_options.ApiKey}");
    }

    public TextGenerationRequestModel CreateRequestModel(string content)
    {
        return new TextGenerationRequestModel
        {
            Model = "gpt-3.5-turbo",
            Messages = new List<TextGenerationMessageModel>
        {
            new TextGenerationMessageModel
            {
                Content = $"Need a placeholder for an article. The answer should be in the format: {Article.Format}",
                Role = "system"
            },
            new TextGenerationMessageModel
            {
                Content = content,
                Role = "user"
            }
        }
        };
    }

    public async Task<Article> GenerateText(TextGenerationRequestModel prompt)
    {
        HttpResponseMessage response = await HttpRawRequest(prompt);
        var responseContentJson = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<GptResponseModel>(responseContentJson);
        var article = JsonConvert.DeserializeObject<Article>(result!.Choices.First()!.Message.Content);

        return article;
    }

    private async Task<HttpResponseMessage> HttpRawRequest(TextGenerationRequestModel prompt)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
        string jsonContent = JsonConvert.SerializeObject(prompt);
        request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        return await _client.SendAsync(request);
    }
}