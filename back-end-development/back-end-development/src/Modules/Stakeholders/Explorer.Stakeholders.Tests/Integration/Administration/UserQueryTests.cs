using Explorer.API.Controllers.Administrator.Administration;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.API.Public.Administration;
using Explorer.Stakeholders.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Stakeholders.Tests.Integration.Administration;

[Collection("Sequential")]
public class UserQueryTests : BaseStakeholdersIntegrationTest
{
    public UserQueryTests(StakeholdersTestFactory factory) : base(factory) {}

    [Fact]
    public void Successfully_gets_paged_users()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        // Act
        var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<UserDto>;

        // Assert
        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(6);
        result.TotalCount.ShouldBe(6);
    }
    
    private static UserManagmentController CreateController(IServiceScope scope)
    {
        return new UserManagmentController(scope.ServiceProvider.GetRequiredService<IUserManagmentService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }
}