using Explorer.Tours.API.Dtos;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Explorer.API.Controllers.Author;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Infrastructure.Database;
using Shouldly;
using Explorer.BuildingBlocks.Core.UseCases;

namespace Explorer.Blog.Tests.Integration;

[Collection("Sequential")]
public class BlogCommandTests : BaseBlogIntegrationTest
{
    public BlogCommandTests(BlogTestFactory factory) : base(factory) { }

    [Fact]
    public void Blog_creation()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();
        var newEntity = new BlogDto
        {
            Name = "test blog",
            Description = "malo tvrdji opis",
            DateCreated = DateTime.Now.ToUniversalTime(),
            Images = new[] { "slikaBloga.jpg", "drugaSlika.png" },
            AuthorId = -11,
            Status = StatusDto.Published,
            Rating = 1,
            Comments = new List<CommentDto>(),
            Ratings = new List<RatingDto>()
        };

        var testComment = new CommentDto();
        var testRating = new RatingDto();

        testComment.UserId = -21;
        testComment.Context = "Komentar";
        testComment.CreationTime = DateTime.Now.ToUniversalTime();
        testComment.LastUpdateTime = DateTime.Now.ToUniversalTime();
        testComment.Author = "slobica";

        testRating.Author = "slobica";
        testRating.RatingType = RatingTypeDto.Upwote;
        testRating.UserId = -21;

        newEntity.Comments.Add(testComment);
        newEntity.Ratings.Add(testRating);


        var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as BlogDto;


        result.ShouldNotBeNull();
        result.Name.ShouldBe(newEntity.Name);

        var storedEntity = dbContext.Blogs.FirstOrDefault(i => i.Name == newEntity.Name);
        storedEntity.ShouldNotBeNull();
    }

    [Fact]
    public void Create_fails_invalid_data()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var updatedEntity = new BlogDto
        {
            Description = "Test",
        };


        var result = (ObjectResult)controller.Create(updatedEntity).Result;

        result.StatusCode.ShouldBe(400);
    }

    [Fact]
    public void Comment_creation()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();
        var newEntity = new BlogDto
        {
            Name = "test blog",
            Description = "malo tvrdji opis",
            DateCreated = DateTime.Now.ToUniversalTime(),
            Images = new[] { "slikaBloga.jpg", "drugaSlika.png" },
            AuthorId = -11,
            Status = StatusDto.Published,
            Rating = 1,
            Comments = new List<CommentDto>(),
            Ratings = new List<RatingDto>()
        };

        var testComment = new CommentDto();

        testComment.UserId = -21;
        testComment.Context = "Komentar";
        testComment.CreationTime = DateTime.Now.ToUniversalTime();
        testComment.LastUpdateTime = DateTime.Now.ToUniversalTime();
        testComment.Author = "slobica";

        var blog = ((ObjectResult)controller.Create(newEntity).Result)?.Value as BlogDto;

        newEntity.Comments.Add(testComment);

        var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as BlogDto;


        result.ShouldNotBeNull();
        result.Name.ShouldBe(newEntity.Name);

        var storedEntity = dbContext.Blogs.FirstOrDefault(i => i.Name == newEntity.Name);
        storedEntity.ShouldNotBeNull();
    }

    [Fact]
    public void Rating_creation()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();
        var newEntity = new BlogDto
        {
            Name = "test blog",
            Description = "malo tvrdji opis",
            DateCreated = DateTime.Now.ToUniversalTime(),
            Images = new[] { "slikaBloga.jpg", "drugaSlika.png" },
            AuthorId = -11,
            Status = StatusDto.Published,
            Rating = 1,
            Comments = new List<CommentDto>(),
            Ratings = new List<RatingDto>()
        };

        var testRating = new RatingDto();


        testRating.Author = "slobica";
        testRating.RatingType = RatingTypeDto.Upwote;
        testRating.UserId = -21;

        newEntity.Ratings.Add(testRating);


        var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as BlogDto;

        result.ShouldNotBeNull();
        result.Name.ShouldBe(newEntity.Name);

        var storedEntity = dbContext.Blogs.FirstOrDefault(i => i.Name == newEntity.Name);
        storedEntity.ShouldNotBeNull();
    }

    private static BlogController CreateController(IServiceScope scope)
    {
        return new BlogController(scope.ServiceProvider.GetRequiredService<IBlogService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }
}