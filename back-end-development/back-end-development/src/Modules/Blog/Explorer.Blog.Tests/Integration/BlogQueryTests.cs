using Explorer.API.Controllers.Administrator.Administration;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.API.Controllers.Author;
using Explorer.Blog.API.Dtos;
using Shouldly;
using Explorer.Blog.API.Public;

namespace Explorer.Blog.Tests.Integration
{
    [Collection("Sequential")]
    public class BlogQueryTest : BaseBlogIntegrationTest
    {
        public BlogQueryTest(BlogTestFactory factory) : base(factory) { }

        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllBlogs(0, 0).Result)?.Value as PagedResult<BlogDto>;

            // Assert
            result.ShouldNotBeNull();

            result.Results.Count.ShouldBe(2);
            result.TotalCount.ShouldBe(2);
        }

        [Fact]
        public void Retrieves_by_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetBlogById(-1).Result)?.Value;

            // Assert
            result.ShouldNotBeNull();
        }


        private static BlogController CreateController(IServiceScope scope)
        {
            return new BlogController(scope.ServiceProvider.GetRequiredService<IBlogService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }

    }
}
