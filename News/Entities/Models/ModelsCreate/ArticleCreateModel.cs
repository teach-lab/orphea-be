namespace News.Entities.Models.ModelsCreate;

public class ArticleCreateModel
{
    public string? Title { get; set; }
    public string? SourceUrl { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public DateTime PublishedAt { get; set; }
    public Guid? PublisherId { get; set; }
}
