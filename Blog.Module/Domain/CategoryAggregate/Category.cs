using Framework.Core.Domain.Entities;

namespace Blog.Module.Domain.CategoryAggregate;

public class Category : BaseEntity
{
    public string Title { get; private set; }
    public string Icon { get; private set; }
    public string Sluge { get; private set; }

}