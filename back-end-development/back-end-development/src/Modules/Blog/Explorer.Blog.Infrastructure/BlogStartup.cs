using Explorer.Blog.API.Public;
using Explorer.Blog.Core.Domain;
using Explorer.Blog.Core.Domain.RepositoryInterfaces;
using Explorer.Blog.Core.Mappers;
using Explorer.Blog.Core.UseCases;
using Explorer.Blog.Infrastructure.Database;
using Explorer.Blog.Infrastructure.Database.Repositories;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.API.Internal;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Explorer.Blog.Infrastructure;

public static class BlogStartup
{
    public static IServiceCollection ConfigureBlogModule(this IServiceCollection services)
    {
        // Registers all profiles since it works on the assembly
        services.AddAutoMapper(typeof(BlogProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }
    
    private static void SetupCore(IServiceCollection services)
    {
        services.AddScoped<IBlogService, BlogService>();
        services.AddScoped<IInternalUserService, UserService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
        services.AddScoped(typeof(ICrudRepository<BlogDom>), typeof(CrudDatabaseRepository<BlogDom, BlogContext>));

        services.AddDbContext<BlogContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("blog"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "blog")));
    }
}