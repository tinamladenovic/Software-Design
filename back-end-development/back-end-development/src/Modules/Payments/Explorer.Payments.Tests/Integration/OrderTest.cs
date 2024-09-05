namespace Explorer.Payments.Tests.Integration
{
    using Explorer.API.Controllers.Author;
    using Explorer.API.Controllers.Tourist.ShoppingCart;
    using Explorer.BuildingBlocks.Core.UseCases;
    using Explorer.Payments.API.Dtos;
    using Explorer.Payments.API.Public.ShoppingCart;
    using Explorer.Payments.Core.Domain;
    using Explorer.Payments.Infrastructure.Database;
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

    public class OrderTest : BasePaymentsIntegrationTest
    {
        public OrderTest(PaymentsTestFactory factory) : base(factory)
        {
        }
        /*[Fact]
       public void Retrieves_all()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            List<long> tourIds = new List<long>();
            tourIds.Add(-124);
            tourIds.Add(-125);

            //Act
            var result = ((ObjectResult)controller.CreateOrder(tourIds, -23).Result);


            //Asert
            //result.ShouldNotBeNull();
            //result.Value.Items.Count.ShouldBe(0);
            //result.Value.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);

        }

        private static OrderController CreateController(IServiceScope scope)
        {
            return new OrderController(scope.ServiceProvider.GetRequiredService<IOrderService>(), scope.ServiceProvider.GetRequiredService<IShoppingCartService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }*/
    }
}
