using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.API.Controllers.Tourist.Execution;
using Explorer.API.Controllers.Tourist.Leaderboards;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Leaderboards;
using Explorer.Tours.API.Public.TourExecution;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.Tourist.Leaderboards
{
    public class TourExecutionLeaderboardQueryTest : BaseToursIntegrationTest
    {
        public TourExecutionLeaderboardQueryTest(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Retrieves_tourists_ranked_by_completed_tours_current_month()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetTouristsRankedByCompletedToursCurrentMonth().Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);
            var rankedTourists = ((PagedResult<TouristCompletedToursDto>)result.Value).Results;

            int leadingTouristCompletedTours = DateTimeHelper.IsStartOfWeekInsideCurrentMonth() ? 8 : 4;

            var leadingTourist = rankedTourists[0];
            leadingTourist.Rank.ShouldBe(1);
            leadingTourist.TouristId.ShouldBe(-21);
            leadingTourist.Name.ShouldBe("Pera");
            leadingTourist.Surname.ShouldBe("Perić");
            leadingTourist.CompletedTours.ShouldBe(leadingTouristCompletedTours);

            rankedTourists[1].Rank.ShouldBe(rankedTourists[2].Rank);
        }

        [Fact]
        public void Retrieves_tourists_ranked_by_covered_distance_current_month()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetTouristsRankedByCoveredDistanceCurrentMonth().Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);
            var rankedTourists = ((PagedResult<TouristCoveredDistanceDto>)result.Value).Results;

            double leadingTouristCompletedDistance = DateTimeHelper.IsStartOfWeekInsideCurrentMonth() ? 13.0 : 6.5;

            var leadingTourist = rankedTourists[0];
            leadingTourist.TouristId.ShouldBe(-22);
            leadingTourist.Name.ShouldBe("Mika");
            leadingTourist.Surname.ShouldBe("Mikić");
            leadingTourist.CoveredDistance.ShouldBe(leadingTouristCompletedDistance);
        }

        [Fact]
        public void Retrieves_tourists_ranked_by_completed_tours_current_week()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetTouristsRankedByCompletedToursCurrentWeek().Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);
            var rankedTourists = ((PagedResult<TouristCompletedToursDto>)result.Value).Results;

            int leadingTouristCompletedTours = DateTimeHelper.IsStartOfMonthInsideCurrentWeek() ? 8 : 4;

            var leadingTourist = rankedTourists[0];
            leadingTourist.Rank.ShouldBe(1);
            leadingTourist.TouristId.ShouldBe(-21);
            leadingTourist.Name.ShouldBe("Pera");
            leadingTourist.Surname.ShouldBe("Perić");
            leadingTourist.CompletedTours.ShouldBe(leadingTouristCompletedTours);

            rankedTourists[1].Rank.ShouldBe(rankedTourists[2].Rank);
        }

        [Fact]
        public void Retrieves_tourists_ranked_by_covered_distance_current_week()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetTouristsRankedByCoveredDistanceCurrentWeek().Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);
            var rankedTourists = ((PagedResult<TouristCoveredDistanceDto>)result.Value).Results;

            double leadingTouristCompletedDistance = DateTimeHelper.IsStartOfMonthInsideCurrentWeek() ? 13.0 : 6.5;

            var leadingTourist = rankedTourists[0];
            leadingTourist.TouristId.ShouldBe(-22);
            leadingTourist.Name.ShouldBe("Mika");
            leadingTourist.Surname.ShouldBe("Mikić");
            leadingTourist.CoveredDistance.ShouldBe(leadingTouristCompletedDistance);
        }

        private static TourExecutionLeaderboardController CreateController(IServiceScope scope, string personId = "-21")
        {
            return new TourExecutionLeaderboardController(scope.ServiceProvider.GetRequiredService<ITourExecutionStatsService>())
            {
                ControllerContext = BuildContext(personId)
            };
        }
    }

    public static class DateTimeHelper
    {
        public static bool IsStartOfWeekInsideCurrentMonth()
        {
            var now = DateTime.UtcNow;
            var startOfWeek = GetStartOfWeek(now);
            return startOfWeek.Month == now.Month;
        }

        public static bool IsStartOfMonthInsideCurrentWeek()
        {
            var now = DateTime.UtcNow;
            var startOfMonth = GetStartOfMonth(now);
            return startOfMonth <= GetEndOfWeek(now) && startOfMonth >= GetStartOfWeek(now);
        }

        private static DateTime GetStartOfWeek(DateTime dateTime)
        {
            var startOfWeek = dateTime.Date.AddDays(-(int)dateTime.DayOfWeek + (int)DayOfWeek.Monday).AddHours(12);
            return startOfWeek;
        }

        private static DateTime GetStartOfMonth(DateTime dateTime)
        {
            var startOfMonth = new DateTime(dateTime.Year, dateTime.Month, 1).AddHours(12);
            return startOfMonth;
        }

        private static DateTime GetEndOfWeek(DateTime dateTime)
        {
            var endOfWeek = dateTime.Date.AddDays(6 - (int)dateTime.DayOfWeek).AddHours(24);
            return endOfWeek;
        }
    }


}
