using Blog.Module.Domain.PostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Module.Persistence.EntityConfigurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(c => c.Id);
        builder.ToTable("Posts");

        builder.Property(c => c.Title).HasMaxLength(300).IsRequired();
        builder.Property(c => c.OwnerName).HasMaxLength(300).IsRequired();
        builder.Property(c => c.Content).HasMaxLength(10000).IsRequired();
        builder.Property(c => c.Visit).HasMaxLength(10);
        builder.Property(c => c.Slug).HasMaxLength(1500).IsRequired();
        
    }
}