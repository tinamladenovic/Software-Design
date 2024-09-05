using Explorer.API.Controllers.Author;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
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
    [Collection("Sequential")]
    public class DestinationCommandTests : BaseToursIntegrationTest
    {
        public DestinationCommandTests(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new DestinationDto
            {
                PersonId = -11,
                Longitude = 25.5745,
                Latitude = -75.89745,
                Name = "Parking 24/7",
                Description = "Parking garaža.",
                ImageURL = "url",
                Type = "Parking"
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as DestinationDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);

            // Assert - Database
            var storedEntity = dbContext.Destinations.FirstOrDefault(i => i.Name == newEntity.Name);
            storedEntity.ShouldNotBeNull();
            storedEntity.Description.ShouldBe(newEntity.Description);
        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new DestinationDto
            {
                PersonId = -11,
                Longitude = 240, //Should be <= -180 && >= 180
                Latitude = -75.89745,
                Name = "Sarajevski ćevap",
                Description = "Autentični sarajevski ćevapi.",
                ImageURL = "url",
                Type = "Restaurant"
            };

            // Act
            var result = (ObjectResult)controller.Create(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);
        }

        [Fact]
        public void Updates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var updatedEntity = new DestinationDto
            {
                Id = -1,
                PersonId = -11,
                Longitude = 55.43,
                Latitude = -75.89745,
                Name = "Grčki gyros",
                Description = "Najbolji gyros u gradu.",
                ImageURL = "url",
                Type = "Restaurant"
            };

            // Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as DestinationDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-1);
            result.Name.ShouldBe(updatedEntity.Name);
            result.Description.ShouldBe(updatedEntity.Description);

            // Assert - Database
            var storedEntity = dbContext.Destinations.FirstOrDefault(i => i.Name == "Grčki gyros");
            storedEntity.ShouldNotBeNull();
            storedEntity.Description.ShouldBe(updatedEntity.Description);
            var oldEntity = dbContext.Destinations.FirstOrDefault(i => i.Name == "Restoran");
            oldEntity.ShouldBeNull();
        }

        [Fact]
        public void Update_fails_invalid_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new DestinationDto
            {
                Id = -110,
                PersonId = -11,
                Longitude = 55.43,
                Latitude = -75.89745,
                Name = "Grčki gyros",
                Description = "Najbolji gyros u gradu.",
                ImageURL = "url",
                Type = "Restaurant"
            };

            // Act
            var result = (ObjectResult)controller.Update(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);
        }

        [Fact]
        public void Deletes()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            // Act
            var result = (OkResult)controller.Delete(-1);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);

            // Assert - Database
            var storedEntity = dbContext.Destinations.FirstOrDefault(i => i.Id == -1);
            storedEntity.ShouldBeNull();
        }

        [Fact]
        public void Delete_fails_invalid_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Delete(-1000);

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);
        }

        private static DestinationController CreateController(IServiceScope scope, string personId = "-11")
        {
            return new DestinationController(scope.ServiceProvider.GetRequiredService<IDestinationService>(), scope.ServiceProvider.GetRequiredService<IDestinationRequestService>())
            {
                ControllerContext = BuildContext(personId)
            };
        }
    }

}
