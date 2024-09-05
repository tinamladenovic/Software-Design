using Explorer.API.Controllers.Author;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration.Author
{
    public class TourCommandTests : BaseToursIntegrationTest
    {
        public TourCommandTests(ToursTestFactory factory) : base(factory) { }

        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new TourDto
            {
                Id = 0,
                AuthorId = -11,
                Name = "Test tour",
                Description = "Ovo je testna tura",
                Difficult = Difficult.Medium,
                TravelTimeAndMethod = new List<TravelTimeAndMethodDto>()
                {
                    new TravelTimeAndMethodDto(TravelMethod.BICYCLE, 15)
                },
                Status = Status.DRAFT,
                Price = 0.0,
                Tags = "tag1,tag2,tag3"
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as TourDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);

            // Assert - Database
            var storedEntity = dbContext.Destinations.FirstOrDefault(i => i.Name == newEntity.Name);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(newEntity.Id);
        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var newEntity = new TourDto
            {
                Description = "Test"
            };

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        private static TourController CreateController(IServiceScope scope)
        {
            return new TourController(scope.ServiceProvider.GetRequiredService<ITourService>(), scope.ServiceProvider.GetRequiredService<ICheckpointService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
