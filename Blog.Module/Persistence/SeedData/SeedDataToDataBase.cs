using Amazon.Runtime.Internal.Util;
using Blog.Module.Domain.CategoryAggregate;
using Blog.Module.Domain.PostAggregate;
using Blog.Module.Persistence.BlogModuleContext;

namespace Blog.Module.Persistence.SeedData;

public static class SeedDataToDataBase
{


    public static void Seed(this BlogContext dbContext)
    {
        dbContext.Database.EnsureCreated();
        if (dbContext.Categories.Any())
        {
            return;
        }
        using var transaction = dbContext.Database.BeginTransaction();
        var createCategories = new List<Category>{
            new ("موبایل", "M", "موبایل"),
            new ("وب", "W", "موبایل"),
            new ("دیتابیس", "D", "دیتابیس"),
            new ("Backend", "B", "Backend"),
        };


        dbContext.Categories.AddRange(createCategories);
        dbContext.SaveChanges();
        Logger.EmptyLogger.InfoFormat("Categories Added To Database Succeeded ! ");

        transaction.Commit();
    }
}
