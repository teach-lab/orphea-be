namespace News.Entities;

public class CommentEntity
{
    public Guid Id { get; set; }
    public string Content { get; set; }

    public Guid UserId { get; set; }
    public Guid ArticleId { get; set; }

    public int LikeCount { get; set; }
    public UserEntity User { get; set; }
}