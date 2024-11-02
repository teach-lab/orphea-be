using News.GptModels;

namespace News.Services.ServicesInterface;

public interface IAiIntegrationService
{
    Task<Article> GenerateText(TextGenerationRequestModel prompt);

    TextGenerationRequestModel CreateRequestModel(string content);
}