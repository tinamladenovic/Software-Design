using Explorer.API.Controllers.Tourist.Wallet;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public.ShoppingCart;
using Explorer.Payments.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Tests.Integration
{
    [Collection("Sequential")]
    public class WalletTest : BasePaymentsIntegrationTest
    {
        public WalletTest(PaymentsTestFactory factory) : base(factory)
        {
        }
        [Fact]
        public void Creates()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<PaymentsContext>();
            var newEntity = new WalletDto(-21, 25);

            var wallet = dbContext.Wallet.Where(sc => sc.Id == newEntity.Id);

            wallet.ShouldNotBeNull();
        }


        [Fact]
        public void Get_Wallet()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            int userId = -21;

            //Act
            var result = ((ObjectResult)controller.Get(userId).Result)?.Value as WalletDto;

            //Asert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-501);

        }

        [Fact]
        public void Update_Wallet()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            int adventureCoins = 25;
            int userId = -21;

            var result = ((ObjectResult)controller.AddCoins(adventureCoins, userId).Result)?.Value as WalletDto;

            result.ShouldNotBeNull();
            result.Id.ShouldBe(-501);
            result.AdventureCoins.ShouldBe(50);

        }

        private static WalletController CreateController(IServiceScope scope)
        {
            return new WalletController(scope.ServiceProvider.GetRequiredService<IWalletService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}