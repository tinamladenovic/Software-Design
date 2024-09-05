namespace Explorer.Tours.Tests.Integration.Tourist
{
    using Explorer.API.Controllers.Author;
    using Explorer.API.Controllers.Tourist;
    using Explorer.API.Controllers.Tourist.ShoppingCart;
    using Explorer.BuildingBlocks.Core.UseCases;
    using Explorer.Payments.API.Dtos;
    using Explorer.Payments.API.Public.ShoppingCart;
    using Explorer.Stakeholders.API.Public;
    using Explorer.Tours.API.Dtos;
    using Explorer.Tours.API.Public.Author;
    using Explorer.Tours.API.Public.Tourist;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Shouldly;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TourOrderTests : BaseToursIntegrationTest
    {
        public TourOrderTests(ToursTestFactory factory) : base(factory)
        {
        }
        [Fact]
        public void Retrieves_all()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            List<long> tourIds = new List<long>();
            tourIds.Add(-124);
            tourIds.Add(-125);

            //Act
            //var result = ((ObjectResult)controller.CreateOrder(0, 0, -21).Result)?.Value as PagedResult<ShoppingCartDto>;


            //Asert
 /*           result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(0);
            result.TotalCount.ShouldBe(0);*/

        }

        private static OrderController CreateController(IServiceScope scope)
        {
            return new OrderController(scope.ServiceProvider.GetRequiredService<IOrderService>(), scope.ServiceProvider.GetRequiredService<IShoppingCartService>(), scope.ServiceProvider.GetRequiredService<IPersonService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
