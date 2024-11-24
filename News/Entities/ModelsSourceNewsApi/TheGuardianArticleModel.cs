using System.Text.Json.Serialization;

namespace News.Entities.ModelsSourceNewsApi;

public class TheGuardianArticleModel
{
    [JsonPropertyName("response")]
    public ResponseTheGuardian Response { get; set; }
}

public class ResponseTheGuardian
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("content")]
    public ContentTheGuardian Content { get; set; }
}

public class ContentTheGuardian
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("webPublicationDate")]
    public string? WebPublicationDate { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }

    [JsonPropertyName("fields")]
    public FieldsArticleTheGuardian Fields { get; set; }
}

public class FieldsArticleTheGuardian
{
    [JsonPropertyName("headline")]
    public string? Headline { get; set; }

    [JsonPropertyName("trailText")]
    public string? TrailText { get; set; }

    [JsonPropertyName("main")]
    public string? Main { get; set; }

    [JsonPropertyName("firstPublicationDate")]
    public DateTime? FirstPublicationDate { get; set; }

    [JsonPropertyName("bodyText")]
    public string? BodyText { get; set; }
}