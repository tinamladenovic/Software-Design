using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.API.Controllers.Tourist.Execution;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.API.Public.Club;
using Explorer.Tours.API.Public.TourExecution;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.Core.Domain.TourExecutions;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.Tourist.Execution;

[Collection("Sequential")]
public class TourExecutionCommandTest : BaseToursIntegrationTest
{
    public TourExecutionCommandTest(ToursTestFactory factory) : base(factory)
    {
    }

    [Theory]
    [InlineData(-125, 200, "-21")]
    [InlineData(-11, 404, "-21")]
    [InlineData(-125, 403, "-12")]
    public void Creates(int tourId, int expectedResponseCode, string touristId)
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, touristId);
        var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

        // Act
        var result = ((ObjectResult)controller.Create(tourId).Result);

        // Assert - Response
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(expectedResponseCode);

        // Assert - Database
        if (expectedResponseCode == 200)
        {
            var storedEntityId = (result?.Value as TourExecutionDto).Id;
            var storedEntity = dbContext.TourExecutions.FirstOrDefault(te => te.Id == storedEntityId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(storedEntityId);
        }
    }

    [Theory]
    [InlineData(-2, 403, Core.Domain.TourExecutions.TourExecutionStatus.Active)]
    [InlineData(-3, 200, Core.Domain.TourExecutions.TourExecutionStatus.Abandoned)]
    public void Abandons(int tourExecutionId, int expectedResponseCode, Core.Domain.TourExecutions.TourExecutionStatus status)
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-21");
        var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

        // Act
        var result = ((ObjectResult)controller.Abandon(tourExecutionId).Result);

        // Assert - Response
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(expectedResponseCode);

        // Assert - Database
        var updatedEntity = dbContext.TourExecutions.FirstOrDefault(te => te.Id == tourExecutionId);
        updatedEntity.ShouldNotBeNull();
        updatedEntity.Status.ShouldBe(status);
    }

    [Theory]
    [MemberData(nameof(ProgressData))]
    public void Updates_progress(TourExecutionUpdateDto currentPosition, bool isCheckpointCompleted)
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-21");
        var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

        // Act
        var result = ((ObjectResult)controller.UpdateProgress(-1, -1, currentPosition).Result)?.Value as TourExecutionDto;

        // Assert - Response
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.CheckpointStatuses.Find(cs => cs.CheckpointId == -1).IsCompleted.ShouldBe(isCheckpointCompleted);

        // Assert - Database
        var updatedEntityId = result.Id;
        var updatedEntity = dbContext.TourExecutions.FirstOrDefault(te => te.Id == updatedEntityId);
        updatedEntity.ShouldNotBeNull();
        updatedEntity.CheckpointStatuses.Find(cs => cs.CheckpointId == -1).IsCompleted.ShouldBe(isCheckpointCompleted);
    }

    [Fact]
    public void Update_progress_fails_unauthorized_user()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-21");
        var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
        var currentPosition = new TourExecutionUpdateDto
        {
            Coordinate = new CoordinateDto
            {
                Latitude = 45.2535M,
                Longitude = 19.8600M
            },
            CoveredDistance = 0.7
        };

        // Act
        var result = ((ObjectResult)controller.UpdateProgress(-2, -1, currentPosition).Result);

        // Assert - Response
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(403);

        // Assert - Database
        var updatedEntity = dbContext.TourExecutions.FirstOrDefault(te => te.Id == -2);
        updatedEntity.ShouldNotBeNull();
        updatedEntity.CheckpointStatuses.Find(cs => cs.CheckpointId == -1).IsCompleted.ShouldBe(false);
    }

    public static IEnumerable<object[]> ProgressData()
    {
        var within50Meters = new TourExecutionUpdateDto
        {
            Coordinate = new CoordinateDto
            {
                Latitude = 45.252750M,
                Longitude = 19.855555M
            },
            CoveredDistance = 0.5
        };

        var within500Meters = new TourExecutionUpdateDto
        {
            Coordinate = new CoordinateDto
            {
                Latitude = 45.2535M,
                Longitude = 19.8600M
            },
            CoveredDistance = 0.7
        };

        return new List<object[]>
        {
            new object[] { within500Meters, false },
            new object[] { within50Meters, true }
        };
    }

    private static TourExecutionController CreateController(IServiceScope scope, string personId)
    {
        return new TourExecutionController(scope.ServiceProvider.GetRequiredService<ITourExecutionService>(), scope.ServiceProvider.GetRequiredService<ITourPreferencesService>(), scope.ServiceProvider.GetRequiredService<ITourRatingService>(), scope.ServiceProvider.GetRequiredService<ITourService>())
        {
            ControllerContext = BuildContext(personId)
        };
    }

}