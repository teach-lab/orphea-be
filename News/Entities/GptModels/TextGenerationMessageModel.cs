using Newtonsoft.Json;

namespace News.GptModels;

public class TextGenerationMessageModel
{
    [JsonProperty("role")]
    public string Role { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }
}