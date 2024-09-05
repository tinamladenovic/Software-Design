using Explorer.API.Controllers.Tourist.Club;
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

namespace Explorer.Stakeholders.Tests.Integration.RequestToJoinClub
{
    [Collection("Sequential")]
    public class RequestsToJoinClubQueryTests : BaseStakeholdersIntegrationTest
    {
        public RequestsToJoinClubQueryTests(StakeholdersTestFactory factory) : base(factory){}

        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<RequestToJoinClubDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(3);
            result.TotalCount.ShouldBe(3);
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
