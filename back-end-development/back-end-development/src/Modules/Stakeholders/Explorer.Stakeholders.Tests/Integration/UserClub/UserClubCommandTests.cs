using Explorer.API.Controllers.Administrator.Administration;
using Explorer.API.Controllers.Tourist.Club;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Infrastructure.Database;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Tests.Integration.UserClub
{
    [Collection("Sequential")]
    public class UserClubCommandTests : BaseStakeholdersIntegrationTest
    {
        public UserClubCommandTests(StakeholdersTestFactory factory) : base(factory) { }
        [Fact]
        public void Deletes()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();

            // Act
            var result = (OkResult)controller.Delete(10,-21);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);

            // Assert - Database
            var storedCourse = dbContext.ClubUsers.FirstOrDefault(i => i.TouristId == -11 && i.TouristClubId==10);
            storedCourse.ShouldBeNull();
        }

        [Fact]
        public void Delete_fails_invalid_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Delete(-1000,1000);

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);
        }

        private static ClubUsersController CreateController(IServiceScope scope)
        {
            return new ClubUsersController(scope.ServiceProvider.GetRequiredService<IClubUsersService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
