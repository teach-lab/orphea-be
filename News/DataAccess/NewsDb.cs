using System.Reflection;
using News.Entities;
using Microsoft.EntityFrameworkCore;

namespace News.DataAccess;

public class NewsDb : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }

    public DbSet<ArticleEntity> Articles { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<ArticleTagEntity> ArticleTags { get; set; }    
    public DbSet<PublisherEntity> Publishers { get; set; }

    public NewsDb(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}