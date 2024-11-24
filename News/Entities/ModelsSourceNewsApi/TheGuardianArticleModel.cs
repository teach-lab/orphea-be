using System.Text.Json.Serialization;

namespace News.Entities.ModelsSourceNewsApi;

public class TheGuardianArticleModel
{
    [JsonPropertyName("response")]
    public ArticleTheG Response { get; set; }
}

public class ArticleTheG
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("content")]
    public ContentModel Content { get; set; }
}

public class ContentModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("webPublicationDate")]
    public string? WebPublicationDate { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }

    [JsonPropertyName("fields")]
    public FieldsArticle Fields { get; set; }
}

public class FieldsArticle
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