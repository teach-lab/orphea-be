namespace News.Entities.Models.ModelsRespones;

public class CommentResponseModel
{
    public Guid Id { get; set; }

    public string Content { get; set; }

    public int LikeCount { get; set; }

    public Guid UserId { get; set; }

    public string FirstName { get; set; }

    public UserResponseModel User { get; set; }

    public Guid ArticleId { get; set; }
}