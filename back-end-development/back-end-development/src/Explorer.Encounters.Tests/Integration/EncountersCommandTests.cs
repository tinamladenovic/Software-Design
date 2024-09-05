using Explorer.API.Controllers.Administrator.Administration;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Explorer.Encounters.Tests.Integration
{
    [Collection("Sequential")]
    public class EncountersCommandTests : BaseEncountersIntegrationTest
    {
        public EncountersCommandTests(EncountersTestFactory factory) : base(factory) { }

        [Theory]
        [InlineData("Skrivena lokacija", EncounterTypeDto.HiddenLocation, 100, "imageUrl.jpeg")]
        public void Creates(string name, EncounterTypeDto encounterType, int range, string? imageUrl)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new EncounterDto
            {
                Name = name,
                Description = "Opis",
                Coordinates = new EncounterCoordinateDto
                {
                    Latitude = (decimal)42.3456,
                    Longitude = (decimal)-22.1345
                },
                Xp = 10,
                Range = range,
                ImageUrl = imageUrl,
                Type = encounterType
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as EncounterDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);
            result.Status.ShouldBe(EncounterStatusDto.Active);

            // Assert - Database
            var storedEntity = dbContext.Encounters.Find(result.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.Name.ShouldBe(result.Name);
        }

        [Fact]
        public void Updates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var updatedEntity = new EncounterDto
            {
                Id = -1,
                Name = "Promenjeno ime",
                Description = "Novi promenjeni opis testne baze",
                Range = 50,
                Coordinates = new EncounterCoordinateDto
                {
                    Latitude = (decimal)35.1234,
                    Longitude = (decimal)-85.5678
                },
            };

            // Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as EncounterDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-1);
            result.Name.ShouldBe(updatedEntity.Name);
            result.Description.ShouldBe(updatedEntity.Description);

            // Assert - Database
            var storedEntity = dbContext.Encounters.FirstOrDefault(i => i.Name == "Promenjeno ime");
            storedEntity.ShouldNotBeNull();
            storedEntity.Description.ShouldBe(updatedEntity.Description);
            var oldEntity = dbContext.Encounters.FirstOrDefault(i => i.Name == "Pogresno ime");
            oldEntity.ShouldBeNull();
        }

        [Fact]
        public void Update_fails_invalid_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new EncounterDto
            {
                Id = -1000,
                Name = "Test"
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
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = (OkResult)controller.Delete(-3);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);

            // Assert - Database
            var storedCourse = dbContext.Encounters.FirstOrDefault(i => i.Id == -3);
            storedCourse.ShouldBeNull();
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

        private static EncounterController CreateController(IServiceScope scope)
        {
            return new EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
