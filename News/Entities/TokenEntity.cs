namespace News.Entities;

public class TokenEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Refresh { get; set; }

    public UserEntity User { get; set; }
}