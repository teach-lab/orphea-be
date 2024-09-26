using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Entities;

namespace News.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<TagEntity>
    {
        public void Configure(EntityTypeBuilder<TagEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.ArticleTags)
                .WithOne(e => e.Tag)
                .HasForeignKey(e => e.TagId);           
        }
    }
}
