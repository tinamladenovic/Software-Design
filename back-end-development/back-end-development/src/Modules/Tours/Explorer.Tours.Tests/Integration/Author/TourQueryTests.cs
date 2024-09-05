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

namespace Explorer.Tours.Tests.Integration.Author
{
    [Collection("Sequential")]
    public class TourQueryTests : BaseToursIntegrationTest
    {
        public TourQueryTests(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Get_author_tours()
        {
            //Arange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.GetAllAuthorTours(-11, 0, 0).Result)?.Value as PagedResult<TourDto>;

            //Asert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(1);
            result.TotalCount.ShouldBe(1);

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
