using Blog.Module.Persistence.BlogModuleContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;

namespace Blog.Module.Infrastructure;

public static class BlogContainerServices
{
    public static IServiceCollection BlogContextRegister(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BlogContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("BlogConnectionString")));

        return services;
    }


    public static IServiceCollection PackagesRegister(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

}