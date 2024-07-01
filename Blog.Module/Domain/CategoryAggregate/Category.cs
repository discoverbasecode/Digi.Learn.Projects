using Blog.Module.Domain.PostAggregate;
using Framework.Core.Domain.Entities;

namespace Blog.Module.Domain.CategoryAggregate;

public class Category : BaseEntity
{
    public string Title { get; private set; }
    public string Icon { get; private set; }
    public string Slug { get; private set; }

    public ICollection<Post> Posts { get; } = new List<Post>();

    public Category() { }
    private Category(string title, string icon, string slug)
    {
        Title = title;
        Icon = icon;
        Slug = slug;
    }

    public static Category Create(string title, string icon, string slug)
    {
        return new Category(title, icon, slug);
    }


    public void Edit(string title, string icon, string slug)
    {
        Title = title;
        Icon = icon;
        Slug = slug;
        LastEdited = DateTime.Now;

    }

    public void Remove()
    {

        IsRemove = true;
        Removed = DateTime.Now;

    }

    public void Restore()
    {

        IsRemove = false;
        Removed = DateTime.Now;

    }

}