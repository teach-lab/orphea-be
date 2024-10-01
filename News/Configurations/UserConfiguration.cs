using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Entities;

namespace News.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(e => e.Id);
        builder.HasMany(e => e.Comments)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);
        builder.HasOne(e => e.Password)
            .WithOne()
            .HasForeignKey<UserEntity>(e => e.PasswordId);
    }
}