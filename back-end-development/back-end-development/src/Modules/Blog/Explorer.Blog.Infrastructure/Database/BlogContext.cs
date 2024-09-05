using Explorer.Blog.Core.Domain;
using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Explorer.Blog.Infrastructure.Database;

public class BlogContext : DbContext
{
    public DbSet<BlogDom> Blogs { get; set; }

    public BlogContext(DbContextOptions<BlogContext> options) : base(options) {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("blog");
        ConfigureBlog(modelBuilder);
    }

    private static void ConfigureBlog(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogDom>().Property(blog => blog.Ratings).HasColumnType("jsonb").HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<Rating>>(v)
        );

        modelBuilder.Entity<BlogDom>().Property(blog => blog.Comments).HasColumnType("jsonb").HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<Comment>>(v)
        );
    }
}