namespace News.Entities.ModelsSourceNewsApi;

public class SourceNewsApiConfigModel
{
    public TheGuardianConfig TheGuardian { get; set; }
}

public class TheGuardianConfig
{
    public string APIKey { get; set; }
    public string BaseUrl { get; set; }
}