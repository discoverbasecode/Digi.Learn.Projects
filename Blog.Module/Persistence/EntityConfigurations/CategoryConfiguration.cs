using Blog.Module.Domain.CategoryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Module.Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.ToTable("Categories");

        builder.Property(c => c.Title).HasMaxLength(300).IsRequired();
        builder.Property(c => c.Icon).HasMaxLength(1000).IsRequired();
        builder.Property(c => c.Sluge).HasMaxLength(1500).IsRequired();
    }
}