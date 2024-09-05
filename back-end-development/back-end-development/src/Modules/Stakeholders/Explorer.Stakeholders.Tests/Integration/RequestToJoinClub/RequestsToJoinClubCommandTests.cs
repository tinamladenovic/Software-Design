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

namespace Explorer.Stakeholders.Tests.Integration.RequestToJoinClub
{
    [Collection("Sequential")]
    public class RequestsToJoinClubCommandTests : BaseStakeholdersIntegrationTest
    {
        public RequestsToJoinClubCommandTests(StakeholdersTestFactory factory) : base(factory){}

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var newEntity = new RequestToJoinClubDto
            {
                Status = 0,
                TouristClubId = 30,
                TouristId = -21
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as RequestToJoinClubDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.TouristId.ShouldBe(newEntity.TouristId);
            result.TouristClubId.ShouldBe(newEntity.TouristClubId);

            // Assert - Database
            var storedEntity = dbContext.RequestsToJoinClub.FirstOrDefault(i => i.TouristId == newEntity.TouristId && i.TouristClubId == newEntity.TouristClubId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new RequestToJoinClubDto
            {
                TouristId = -280,
                TouristClubId = 60,
                Status = 0
            };

            // Act
            var result = (ObjectResult)controller.Create(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Updates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var updatedEntity = new RequestToJoinClubDto
            {
                Id = -1,
                TouristClubId = 10,
                TouristId = -11,
                Status = 0
            };

            // Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as RequestToJoinClubDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-1);
            result.TouristClubId.ShouldBe(updatedEntity.TouristClubId);
            result.TouristId.ShouldBe(updatedEntity.TouristId);

            // Assert - Database
            var storedEntity = dbContext.RequestsToJoinClub.FirstOrDefault(i => i.TouristClubId == 10);
            storedEntity.ShouldNotBeNull();
            storedEntity.TouristClubId.ShouldBe(updatedEntity.TouristClubId);
            var oldEntity = dbContext.RequestsToJoinClub.FirstOrDefault(i => i.TouristClubId == 40);
            oldEntity.ShouldBeNull();
        }

        [Fact]
        public void Update_fails_invalid_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new RequestToJoinClubDto
            {
                Id = -6969,
                TouristClubId = -6969,
                TouristId = 6969,
                Status = 0
            };

            // Act
            var result = (ObjectResult)controller.Update(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);
        }

        [Fact]
        public void Deletes()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();

            // Act
            var result = (OkResult)controller.Delete(-3);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);

            // Assert - Database
            var storedCourse = dbContext.RequestsToJoinClub.FirstOrDefault(i => i.Id == -3);
            storedCourse.ShouldBeNull();
        }

        [Fact]
        public void Delete_fails_invalid_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Delete(-1000);

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);
        }

        private static RequestToJoinClubController CreateController(IServiceScope scope)
        {
            return new RequestToJoinClubController(scope.ServiceProvider.GetRequiredService<IRequestToJoinClubService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }



    }
}
