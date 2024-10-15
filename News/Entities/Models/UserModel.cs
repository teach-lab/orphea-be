namespace News.Entities.Models;

public class UserModel
{
    public Guid? Id { get; set; }
    public string? FirstName { get; set; }
    public string? Password { get; set; }
    public byte[]? Salt { get; set; }
    public string? Email { get; set; }
    public string? Login { get; set; }
}