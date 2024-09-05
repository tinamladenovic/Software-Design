using Explorer.API.Controllers.Tourist.Execution;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.TourExecution;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration.Tourist.Execution
{
    [Collection("Sequential")]
    public class TourExecutionStatsQueryTest : BaseToursIntegrationTest
    {
        public TourExecutionStatsQueryTest(ToursTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void Retrieves_all_completed_count()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-21");

            // Act
            var result = (ObjectResult)controller.GetCompletedTourExecutionCount().Result;

            // Assert
            result.ShouldNotBeNull();
            result.Value.ShouldBe(20);
        }

        [Fact]
        public void Retrieves_tourist_completed_count()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-21");

            // Act
            var result = (ObjectResult)controller.GetTouristCompletedTourExecutionCount().Result;

            // Assert
            result.ShouldNotBeNull();
            result.Value.ShouldBe(8);
        }

        [Fact]
        public void Retrieves_total_covered_distance()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-21");

            // Act
            var result = (ObjectResult)controller.GetTotalCoveredDistance().Result;

            // Assert
            result.ShouldNotBeNull();
            result.Value.ShouldBe(35.2);
        }

        [Fact]
        public void Retrieves_tourist_total_covered_distance()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-21");

            // Act
            var result = (ObjectResult)controller.GetTouristTotalCoveredDistance().Result;

            // Assert
            result.ShouldNotBeNull();
            result.Value.ShouldBe(13.2);
        }

        private static TourExecutionStatsController CreateController(IServiceScope scope, string personId)
        {
            return new TourExecutionStatsController(scope.ServiceProvider.GetRequiredService<ITourExecutionStatsService>())
            {
                ControllerContext = BuildContext(personId)
            };
        }
    }

}
