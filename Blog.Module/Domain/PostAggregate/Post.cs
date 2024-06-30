using Blog.Module.Domain.CategoryAggregate;
using Framework.Core.Domain.Entities;

namespace Blog.Module.Domain.PostAggregate;

public class Post : BaseEntity
{
    public string Title { get; private set; }
    public string OwnerName { get; private set; }
    public string Content { get; private set; }
    public string ImageName { get; private set; }
    public long Visit { get; private set; }
    public string Slug { get; private set; }

    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; } // Required foreign key property
    public Category Category { get; set; } = null!; // Required reference navigation to principal

    public Post(string title, string ownerName, string content, string imageName, long visit, string slug, Category category)
    {
        Title = title;
        OwnerName = ownerName;
        Content = content;
        ImageName = imageName;
        Visit = visit;
        Slug = slug;
        Category = category;
    }
}