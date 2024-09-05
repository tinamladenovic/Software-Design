using Explorer.API.Controllers.Author;
using Explorer.API.Controllers.Tourist;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration.Tourist
{
    public class CompositeTourCommandTests : BaseToursIntegrationTest
    {
        public CompositeTourCommandTests(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new CompositeTourDto
            {
                TouristId = -23,
                Name = "Foo",
                Tours = new List<TourDto>(),
                
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as CompositeTourDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);

        }

        //[Fact]
        //public void Create_fails_invalid_data()
        //{
        //    // Arrange
        //    using var scope = Factory.Services.CreateScope();
        //    var controller = CreateController(scope);
        //    var newEntity = new CompositeTourDto
        //    {
        //        Name = ""
        //    };

        //    // Act
        //    var result = (ObjectResult)controller.Create(newEntity).Result;

        //    // Assert
        //    result.ShouldNotBeNull();
        //    result.StatusCode.ShouldBe(400);
        //}

        private static CompositeTourController CreateController(IServiceScope scope)
        {
            return new CompositeTourController(scope.ServiceProvider.GetRequiredService<ICompositeTourService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
