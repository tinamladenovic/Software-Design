namespace Explorer.Tours.Tests.Integration.Tourist
{
    using Explorer.API.Controllers.Author;
    using Explorer.BuildingBlocks.Core.UseCases;
    using Explorer.Tours.API.Dtos;
    using Explorer.Tours.API.Public.Author;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Shouldly;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AvailableTourTests : BaseToursIntegrationTest
    {
        public AvailableTourTests(ToursTestFactory factory) : base(factory)
        {
        }
        [Fact]
        public void Retrieves_all()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.GetAllAvailableTours(0, 0, -21).Result)?.Value as PagedResult<TourPreviewDto>;


            //Asert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(0);
            result.TotalCount.ShouldBe(0);

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
