using Explorer.API.Controllers.Administrator.Administration;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration.Administration
{
    [Collection("Sequential")]
    public class ReportQueryTests : BaseToursIntegrationTest
    {
        public ReportQueryTests(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll(0,0).Result)?.Value as PagedResult<ReportDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(2);
            result.TotalCount.ShouldBe(2);
        }

        private static ReportController CreateController(IServiceScope scope)
        {
            return new ReportController(scope.ServiceProvider.GetRequiredService<IReportService>(), scope.ServiceProvider.GetRequiredService<IReportCommentService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
