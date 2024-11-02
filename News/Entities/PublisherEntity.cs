namespace News.Entities;

public class PublisherEntity : BaseEntity
{
    public string Name { get; set; }

    public int TrustScore { get; set; }

    public List<ArticleEntity> Articles { get; set; }
}