namespace News.Entities;

public class UserEntity : BaseEntity
{
    public string? FirstName { get; set; }

    public string? Email { get; set; }

    public string? Login { get; set; }

    public Guid? PasswordId { get; set; }

    public PasswordEntity? Password { get; set; }

    public List<CommentEntity>? Comments { get; set; }

    public List<TokenEntity>? RefreshTokens { get; set; }
}