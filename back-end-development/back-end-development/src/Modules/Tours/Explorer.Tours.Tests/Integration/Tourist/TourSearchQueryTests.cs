using Explorer.API.Controllers.Author;
using Explorer.API.Controllers.Tourist;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.Tourist
{
    [Collection("Sequential")]

    public class TourSearchQueryTests : BaseToursIntegrationTest
    {
        public TourSearchQueryTests(ToursTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetAllToursInRange_ShouldReturnToursWithinRange()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            TourSearchDto tourSearchDto = new TourSearchDto
            {
                Latitude = 45.388215726730124M,
                Longitude = 20.391394604895087M,
                Range = 100000
            };

            // Act
            var result = await controller.GetAllToursInRange(tourSearchDto);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldNotBeOfType<NotFoundResult>(); 

            
            var okResult = result.ShouldBeOfType<ActionResult<TourDto>>();
            okResult.Result.ShouldBeOfType<OkObjectResult>();

            var tours = ((OkObjectResult)okResult.Result).Value as IEnumerable<TourDto>;

            tours.ShouldNotBeNull();
            tours.ShouldNotBeEmpty();

            
        }


        private static TourSearchController CreateController(IServiceScope scope)
        {
            return new TourSearchController(scope.ServiceProvider.GetRequiredService<ICheckpointService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
