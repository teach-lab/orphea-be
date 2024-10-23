namespace News.Entities.Models;

public class ArticleModel
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? SourceUrl { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public DateTime PublishedAt { get; set; }

    public int? TrustScore { get; set; }

    public Guid? PublisherId { get; set; }

    public List<TagModel>? Tags { get; set; }
}