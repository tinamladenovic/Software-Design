using Explorer.API.Controllers.Administrator.Administration;
using Explorer.API.Controllers.Tourist.Execution;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Infrastructure.Database;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos.Execution;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Tests.Integration
{
    [Collection("Sequential")]
    public class HiddenLocEncounterExecutionTests : BaseEncountersIntegrationTest
    {
        public HiddenLocEncounterExecutionTests(EncountersTestFactory factory) : base(factory) { }

        [Theory]
        [MemberData(nameof(CreatesData))]

        public void Creates(EncounterCoordinateDto currentPosition, long encounterId, int expectedResponseCode, string touristId)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, touristId);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = ((ObjectResult)controller.Activate(encounterId, currentPosition).Result);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            // Assert - Database
            if (expectedResponseCode == 200)
            {
                var storedEntityId = (result?.Value as EncounterExecutionDto).Id;
                var storedEntity = dbContext.EncounterExecutions.FirstOrDefault(te => te.Id == storedEntityId);
                storedEntity.ShouldNotBeNull();
                storedEntity.Id.ShouldBe(storedEntityId);
                storedEntity.Status.ShouldBe(EncounterExecutionStatus.Active);
                storedEntity.LastPosition.Longitude.ShouldBe(currentPosition.Longitude);
                storedEntity.LastPosition.Latitude.ShouldBe(currentPosition.Latitude);
            }
        }

        [Theory]
        [InlineData("-22", -1, 403)]
        [InlineData("-21", -1, 200)]
        [InlineData("-21", -4, 400)]
        public void Abandons(string personId, long executionId, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, personId);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = ((ObjectResult)controller.Abandon(executionId).Result);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);
            if (expectedResponseCode != 200)
            {
                return;
            }
            result.Value.ShouldNotBeNull();
            (result.Value as EncounterExecutionDto).Status.ShouldBe(EncounterExecutionStatusDto.Abandoned);

            // Assert - Database
            var storedEntityId = (result?.Value as EncounterExecutionDto).Id;
            var storedEntity = dbContext.EncounterExecutions.FirstOrDefault(te => te.Id == storedEntityId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(storedEntityId);
            storedEntity.Status.ShouldBe(EncounterExecutionStatus.Abandoned);
        }

        [Theory]
        [MemberData(nameof(UpdatesProgressData))]
        public void ChecksIfCompleted(EncounterCoordinateDto currentPosition, long executionId, EncounterExecutionStatusDto expectedStatus, bool shouldEnterLocation)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = ((ObjectResult)controller.CheckIfCompleted(executionId, currentPosition).Result)?.Value as EncounterExecutionDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(executionId);
            result.LastActivity.ShouldBeInRange(DateTime.UtcNow.AddSeconds(-1), DateTime.UtcNow);
            result.LastPosition.ShouldBe(currentPosition);
            result.LocationEntryTimestamp.HasValue.ShouldBe(shouldEnterLocation);
            result.Status.ShouldBe(expectedStatus);

            // Assert - Database
            var storedEntityId = result.Id;
            var storedEntity = dbContext.EncounterExecutions.FirstOrDefault(te => te.Id == storedEntityId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(storedEntityId);
            storedEntity.LastPosition.Longitude.ShouldBe(currentPosition.Longitude);
            storedEntity.LastPosition.Latitude.ShouldBe(currentPosition.Latitude);
            storedEntity.LastActivity.ShouldBe(result.LastActivity);
            storedEntity.Status.ToString().ShouldBe(expectedStatus.ToString());
        }

        public static IEnumerable<object[]> CreatesData()
        {
            var within50Meters = new EncounterCoordinateDto
            {
                Latitude = 40.6786M,
                Longitude = -75.4324M
            };

            var notWithin50Meters = new EncounterCoordinateDto
            {
                Latitude = 40.6776M,
                Longitude = -75.4336M
            };

            return new List<object[]>
            {
                new object[] { notWithin50Meters, -2, 400 , "-21" },
                new object[] { within50Meters, -6, 200, "-23" },
                new object[] { within50Meters, -4, 404, "-21" },
                new object[] { within50Meters, -100, 404, "-21" }
            };
        }

        public static IEnumerable<object[]> UpdatesProgressData()
        {
            var within5Meters = new EncounterCoordinateDto
            {
                Latitude = 40.678923M,
                Longitude = -75.432146M
            };

            var notWithin5Meters = new EncounterCoordinateDto
            {
                Latitude = 40.6776M,
                Longitude = -75.4336M
            };

            return new List<object[]>
            {
                new object[] { notWithin5Meters, -2, EncounterExecutionStatusDto.Active, false },
                new object[] { within5Meters, -2, EncounterExecutionStatusDto.Active, true },
                new object[] { within5Meters, -3, EncounterExecutionStatusDto.Completed, true }
            };
        }

        private static EncounterExecutionController CreateController(IServiceScope scope, string personId)
        {
            return new EncounterExecutionController(scope.ServiceProvider.GetRequiredService<IEncounterExecutionService>(),
                                      scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildContext(personId)
            };
        }
    }
}
