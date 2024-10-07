namespace News.Entities.Models;

public class CommentCreateModel
{
    public string Content { get; set; }

    public string UserId { get; set; }

    public string ArticleId { get; set; }
}
