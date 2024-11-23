using System.Text.Json.Serialization;

public class TheGuardianModel
{
    [JsonPropertyName("response")]
    public Response Response { get; set; }
}

public class Response
{
    [JsonPropertyName("startIndex")]
    public int StartIndex { get; set; }

    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("pages")]
    public int Pages { get; set; }

    [JsonPropertyName("orderBy")]
    public string OrderBy { get; set; }

    [JsonPropertyName("results")]
    public List<ResultArticles> Results { get; set; }
}

public class ResultArticles
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("sectionId")]
    public string SectionId { get; set; }

    [JsonPropertyName("sectionName")]
    public string SectionName { get; set; }

    [JsonPropertyName("webPublicationDate")]
    public string WebPublicationDate { get; set; }

    [JsonPropertyName("webTitle")]
    public string WebTitle { get; set; }

    [JsonPropertyName("webUrl")]
    public string WebUrl { get; set; }

    [JsonPropertyName("apiUrl")]
    public string ApiUrl { get; set; }

    [JsonPropertyName("isHosted")]
    public bool IsHosted { get; set; }

    [JsonPropertyName("pillarId")]
    public string PillarId { get; set; }

    [JsonPropertyName("pillarName")]
    public string PillarName { get; set; }
}