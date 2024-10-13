using Microsoft.EntityFrameworkCore;
using News.Entities;
using System.Reflection;

namespace News.DataAccess;

public class NewsDb : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public DbSet<CommentEntity> Comments { get; set; }

    public DbSet<ArticleEntity> Articles { get; set; }

    public DbSet<TagEntity> Tags { get; set; }

    public DbSet<ArticleTagEntity> ArticleTags { get; set; }

    public DbSet<PublisherEntity> Publishers { get; set; }

    public DbSet<PasswordEntity> Password { get; set; }

    public DbSet<TokenEntity> Tokens { get; set; }

    public NewsDb(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}