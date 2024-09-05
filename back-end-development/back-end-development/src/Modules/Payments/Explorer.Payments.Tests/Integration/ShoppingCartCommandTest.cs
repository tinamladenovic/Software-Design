using Explorer.API.Controllers.Author;
using Microsoft.Extensions.DependencyInjection;
using Explorer.API.Controllers.Tourist.ShoppingCart;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.Infrastructure.Database;
using Shouldly;
using Explorer.Payments.API.Public.ShoppingCart;

namespace Explorer.Payments.Tests.Integration
{
    [Collection("Sequential")]
    public class ShoppingCartCommandTest : BasePaymentsIntegrationTest
    {
        public ShoppingCartCommandTest(PaymentsTestFactory factory) : base(factory)
        {
        }
        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<PaymentsContext>();
            var newItem = new OrderItemDto(-124, "Neki nejm", 5);
            var newEntity = new ShoppingCartDto(-21, new List<OrderItemDto>());
            newEntity.Items.Add(newItem);

            var shoppingCart = dbContext.ShoppingCart.Where(sc => sc.Id == newEntity.Id);

            shoppingCart.ShouldNotBeNull();
        }
        private static ShoppingCartController CreateController(IServiceScope scope)
        {
            return new ShoppingCartController(scope.ServiceProvider.GetRequiredService<IShoppingCartService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
    
}