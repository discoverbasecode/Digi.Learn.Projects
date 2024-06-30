using Blog.Module.Domain.CategoryAggregate;
using Blog.Module.Persistence.BlogModuleContext;
using Framework.Core.Persistence.Repositories;

namespace Blog.Module.Persistence.Repositories;

public class CategoryRepository(BlogContext context)
    : BaseRepository<Category, BlogContext>(context), ICategoryRepository;
