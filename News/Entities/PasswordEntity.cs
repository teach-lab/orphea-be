namespace News.Entities;

public class PasswordEntity
{
    public Guid Id { get; set; }

    public string Hash { get; set; }

    public byte[] Salt { get; set; }
}