namespace News.Entities;

public class ArticleEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string SourceUrl { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public DateTime PublishedAt { get; set; }
    public int TrustScore { get; set; }

    public Guid PublisherId { get; set; }
    public PublisherEntity? Publisher { get; set; }

    public List<ArticleTagEntity>? ArticleTags { get; set; } = new List<ArticleTagEntity>();
}
