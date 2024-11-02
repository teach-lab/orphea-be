namespace News.Entities;

public class TokenEntity : BaseEntity
{
    public Guid UserId { get; set; }

    public string Refresh { get; set; }

    public UserEntity User { get; set; }
}