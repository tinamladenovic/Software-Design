using Explorer.API.Controllers.Tourist;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
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
    public class FollowersQueryTests : BaseStakeholdersIntegrationTest
    {
        public FollowersQueryTests(StakeholdersTestFactory factory) : base(factory) { }

        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<FollowersDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(3);
            result.TotalCount.ShouldBe(3);
        }

        [Fact]
        public void Retrieves_Followed_For_User()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = controller.GetFollowingForUser(-11);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result[0].ShouldBe(-21);
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
