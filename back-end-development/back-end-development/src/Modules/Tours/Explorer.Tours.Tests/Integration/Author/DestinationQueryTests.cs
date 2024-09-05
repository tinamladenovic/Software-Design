using Explorer.API.Controllers.Administrator.Administration;
using Explorer.API.Controllers.Author;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
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
    public class DestinationQueryTests: BaseToursIntegrationTest
    {
        public DestinationQueryTests(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<DestinationDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(3);
            result.TotalCount.ShouldBe(3);
        }

        [Fact]
        public void Retrieves_valid_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.Get(-1).Result)?.Value as DestinationDto;

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-1);
        }

        [Fact]
        public void Retrieve_fails_invalid_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Get(99).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);
        }

        private static DestinationController CreateController(IServiceScope scope)
        {
            return new DestinationController(scope.ServiceProvider.GetRequiredService<IDestinationService>(), scope.ServiceProvider.GetRequiredService<IDestinationRequestService>())
            {
                ControllerContext = BuildContext("-11")
            };
        }
    }
}
