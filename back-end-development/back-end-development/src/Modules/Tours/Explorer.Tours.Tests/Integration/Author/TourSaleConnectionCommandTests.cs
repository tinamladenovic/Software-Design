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
    [Collection("Sequential")]
    public class TourSaleConnectionCommandTests : BaseToursIntegrationTest
    {
        public TourSaleConnectionCommandTests(ToursTestFactory factory) : base(factory) { }
        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new TourSaleConnectionDto
            {
                TourId = -123,
                SaleId = 3
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as TourSaleConnectionDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.TourId.ShouldBe(newEntity.TourId);
            result.SaleId.ShouldBe(newEntity.SaleId);

            // Assert - Database
            var storedEntity = dbContext.TourSaleConnections.FirstOrDefault(tsc => tsc.TourId == newEntity.TourId && tsc.SaleId == newEntity.SaleId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var newEntity = new TourSaleConnectionDto
            {
                TourId = -1123,
                SaleId = 332
            };

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }
        private static TourSaleConnectionController CreateController(IServiceScope scope)
        {
            return new TourSaleConnectionController(scope.ServiceProvider.GetRequiredService<ITourSaleConnectionService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
