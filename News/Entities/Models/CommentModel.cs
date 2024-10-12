namespace News.Entities.Models;

public class CommentModel
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public int LikeCount { get; set; }

    public Guid UserId { get; set; }

    public Guid ArticleId { get; set; }

}