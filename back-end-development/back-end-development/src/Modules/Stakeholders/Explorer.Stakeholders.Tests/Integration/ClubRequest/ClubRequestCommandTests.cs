using Explorer.API.Controllers.Administrator.Administration;
using Explorer.API.Controllers.Tourist.Club;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Infrastructure.Database;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Tests.Integration.ClubRequest
{
    [Collection("Sequential")]
    public class ClubRequestCommandTests : BaseStakeholdersIntegrationTest
    {
        public ClubRequestCommandTests(StakeholdersTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var newEntity = new ClubRequestDto
            {
                TouristId = -21,
                TouristClubId = 30,
                Status = 0
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as ClubRequestDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.TouristId.ShouldBe(newEntity.TouristId);
            result.TouristClubId.ShouldBe(newEntity.TouristClubId);

            // Assert - Database
            var storedEntity = dbContext.ClubRequests.FirstOrDefault(i => i.TouristId == newEntity.TouristId && i.TouristClubId == newEntity.TouristClubId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var newEntity = new ClubRequestDto
            {
                TouristId = -280,
                TouristClubId = 60,
                Status = 0
            };

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        private static ClubRequestController CreateController(IServiceScope scope)
        {
            return new ClubRequestController(scope.ServiceProvider.GetRequiredService<IClubRequestService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
