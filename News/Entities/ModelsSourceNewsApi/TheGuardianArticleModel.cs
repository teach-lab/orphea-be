using System.Text.Json.Serialization;

namespace News.Entities.ModelsSourceNewsApi
{
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

        [JsonPropertyName("standfirst")]
        public string? Standfirst { get; set; }

        [JsonPropertyName("trailText")]
        public string? TrailText { get; set; }

        [JsonPropertyName("main")]
        public string? Main { get; set; }

        [JsonPropertyName("wordcount")]
        public string? Wordcount { get; set; }

        [JsonPropertyName("firstPublicationDate")]
        public DateTime? FirstPublicationDate { get; set; }

        [JsonPropertyName("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonPropertyName("liveBloggingNow")]
        public string? LiveBloggingNow { get; set; }

        [JsonPropertyName("publication")]
        public string? Publication { get; set; }

        [JsonPropertyName("thumbnail")]
        public string? Thumbnail { get; set; }

        [JsonPropertyName("legallySensitive")]
        public string? LegallySensitive { get; set; }

        [JsonPropertyName("lang")]
        public string? Lang { get; set; }

        [JsonPropertyName("isLive")]
        public string? IsLive { get; set; }

        [JsonPropertyName("charCount")]
        public string? CharCount { get; set; }

        [JsonPropertyName("bylineHtml")]
        public string? BylineHtml { get; set; }

        [JsonPropertyName("showTableOfContents")]
        public string? ShowTableOfContents { get; set; }

        [JsonPropertyName("body")]
        public string? Body { get; set; }

        [JsonPropertyName("bodyText")]
        public string? BodyText { get; set; }
    }
}