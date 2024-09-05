using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.API.Controllers.Tourist;
using Explorer.API.Controllers.Tourist.Execution;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public.PaymentRecord;
using Explorer.Payments.API.Public.TourBundle;
using Explorer.Payments.Infrastructure.Database;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.API.Public.TourExecution;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Payments.Tests.Integration
{
    public class TourBundleCommandTest : BasePaymentsIntegrationTest
    {
        public TourBundleCommandTest(PaymentsTestFactory factory) : base(factory)
        {
        }

        [Theory]
        [InlineData(-111, 99.99,200, "-21")]
        [InlineData(-113, 99.99, 404, "-21")]
        //[InlineData(-111, 99.99, 403, "-11")]
        public void PurchaseBundle(long bundleId, double amount, int expectedResponseCode, string touristId)
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, touristId);
            var dbContext = scope.ServiceProvider.GetRequiredService<PaymentsContext>();
            // Act
            var result = ((ObjectResult)controller.Create((int)bundleId, amount).Result);

            // Assert - response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            // Assert - database
            if(expectedResponseCode == 200)
            {
                var storedEntityId = (result?.Value as PaymentRecordDto).Id;
                var storedEntity = dbContext.PaymentRecords.FirstOrDefault(te => te.Id == storedEntityId);
                storedEntity.ShouldNotBeNull();
                storedEntity.Id.ShouldBe(storedEntityId);
            }
        }
        private static TourBundleTouristController CreateController(IServiceScope scope, string personId)
        {
            return new TourBundleTouristController(scope.ServiceProvider.GetRequiredService<IPaymentRecordService>(), scope.ServiceProvider.GetRequiredService<ITourBundleService>(), scope.ServiceProvider.GetRequiredService<ICouponService>())
            {
                ControllerContext = BuildContext(personId)
            };
        }
    }
}
