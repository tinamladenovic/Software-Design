using Explorer.API.Controllers.Author;
using Explorer.API.Controllers.Tourist;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.Tests.Integration.Author;
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
    public class CompositeTourQueryTests : BaseToursIntegrationTest
    {
        public CompositeTourQueryTests(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Get_author_tours()
        {
            //Arange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.GetAllCompositeTours(-23, 0, 0).Result)?.Value as PagedResult<CompositeTourDto>;

            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(2);
            result.TotalCount.ShouldBe(2);


        }
        private static CompositeTourController CreateController(IServiceScope scope)
        {
            return new CompositeTourController(scope.ServiceProvider.GetRequiredService<ICompositeTourService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }


    }
}
