namespace News.Entities.Models;

public class CommentResponseModel
{
    public Guid Id { get; set; }

    public string Comment { get; set; }

    public Guid UserId { get; set; }

    public Guid ArticleId { get; set; }

    public int LikeCount { get; set; }

    public string Username { get; set; }

    public UserResponseModel User { get; set; }
}