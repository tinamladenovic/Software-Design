using Explorer.API.Controllers.Tourist.Execution;
using Explorer.Tours.API.Public.TourExecution;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.API.Controllers.Author;
using Explorer.Payments.API.Public.TourBundle;
using Explorer.Payments.Tests;
using Microsoft.AspNetCore.Mvc;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.Tourist.TourBundle
{
    [Collection("Sequential")]
    public class TourBundleQueryTest : BasePaymentsIntegrationTest
    {
        public TourBundleQueryTest(PaymentsTestFactory factory) : base(factory)
        {
        }
        [Fact]
        public void Retrieves_all_completed_count()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-12");

            // Act
            var result = (ObjectResult)controller.GetAll(1, 2).Result;

            // Assert
            result.ShouldNotBeNull();
        }

        private static TourBundleController CreateController(IServiceScope scope, string personId)
        {
            return new TourBundleController(scope.ServiceProvider.GetRequiredService<ITourBundleService>())
            {
                ControllerContext = BuildContext(personId)
            };
        }
    }
}
