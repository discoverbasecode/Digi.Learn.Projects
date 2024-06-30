using Blog.Module.Domain.CategoryAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Blog.Module.Domain.PostAggregate;

namespace Blog.Module.Persistence.BlogModuleContext;

public class BlogContext(DbContextOptions<BlogContext> options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Post> Posts => Set<Post>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }


}