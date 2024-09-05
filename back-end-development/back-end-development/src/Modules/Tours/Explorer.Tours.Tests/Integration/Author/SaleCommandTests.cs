using Explorer.API.Controllers.Author;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Infrastructure.Database;
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
    [Collection("Sequential")]
    public class SaleCommandTests : BaseToursIntegrationTest
    {
        public SaleCommandTests(ToursTestFactory factory) : base(factory) { }
        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new SaleDto
            {
                StartDate = DateTime.UtcNow.AddDays(1),
                EndDate = DateTime.UtcNow.AddDays(2),
                Percent = 12,
                AuthorId = 1
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as SaleDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Percent.ShouldBe(newEntity.Percent);
            result.AuthorId.ShouldBe(newEntity.AuthorId);

            // Assert - Database
            var storedEntity = dbContext.Sales.FirstOrDefault(s => s.StartDate == newEntity.StartDate && s.EndDate == newEntity.EndDate && s.Percent==newEntity.Percent && s.AuthorId==newEntity.AuthorId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var newEntity = new SaleDto
            {
                StartDate = DateTime.UtcNow.AddDays(-15),
                EndDate = DateTime.UtcNow.AddDays(2),
                Percent = 15,
                AuthorId = 61
            };

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }
        [Fact]
        public void Updates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var updatedEntity = new SaleDto
            {
                Id = 1,
                StartDate = DateTime.UtcNow.AddDays(1),
                EndDate = DateTime.UtcNow.AddDays(2),
                Percent = 12,
                AuthorId = 1
            };

            // Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as SaleDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
            result.Percent.ShouldBe(updatedEntity.Percent);
            result.StartDate.ShouldBe(updatedEntity.StartDate);

            // Assert - Database
            var storedEntity = dbContext.Sales.FirstOrDefault(s => s.Percent == 12);
            storedEntity.ShouldNotBeNull();
            storedEntity.Percent.ShouldBe(updatedEntity.Percent);
            var oldEntity = dbContext.Sales.FirstOrDefault(s => s.Percent == 15);
            oldEntity.ShouldBeNull();
        }


        [Fact]
        public void Deletes()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            // Act
            var result = (OkObjectResult)controller.Delete(3);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);

            // Assert - Database
            var storedCourse = dbContext.Sales.FirstOrDefault(s => s.Id == 3);
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
        }





        private static SaleController CreateController(IServiceScope scope)
        {
            return new SaleController(scope.ServiceProvider.GetRequiredService<ISaleService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
