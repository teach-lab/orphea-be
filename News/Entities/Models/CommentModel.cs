namespace News.Entities.Models;

public class CommentModel
{
    public Guid Id { get; set; }

    public string Comment { get; set; }

    public Guid UserId { get; set; }

    public Guid ArticleId { get; set; }

    public int LikeCount { get; set; }
}
//should add created at and updated at? 
//rename comment to content