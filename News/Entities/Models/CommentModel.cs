namespace News.Entities.Models;

public class CommentModel
{
    public string Comment { get; set; }

    public Guid UserId { get; set; }

    public Guid ArticleId { get; set; }

    public int LikeCount { get; set; }
}
