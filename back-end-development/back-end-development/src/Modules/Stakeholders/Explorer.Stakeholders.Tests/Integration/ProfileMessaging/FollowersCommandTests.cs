using Explorer.API.Controllers.Tourist;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Tests.Integration.ProfileMessaging
{
    [Collection("Sequential")]
    public class FollowersCommandTests : BaseStakeholdersIntegrationTest
    {
        public FollowersCommandTests(StakeholdersTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var newEntity = new FollowersDto
            {
                FollowedId = -11,
                FollowingId = -22
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as FollowersDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.FollowedId.ShouldBe(newEntity.FollowedId);
            result.FollowingId.ShouldBe(newEntity.FollowingId);

            // Assert - Database
            var storedEntity = dbContext.Followers.FirstOrDefault(i => i.FollowedId == newEntity.FollowedId && i.FollowingId == newEntity.FollowingId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var newEntity = new FollowersDto
            {
                FollowedId = -280,
                FollowingId = 60,
            };

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        private static FollowersController CreateController(IServiceScope scope)
        {
            return new FollowersController(scope.ServiceProvider.GetRequiredService<IFollowersService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
