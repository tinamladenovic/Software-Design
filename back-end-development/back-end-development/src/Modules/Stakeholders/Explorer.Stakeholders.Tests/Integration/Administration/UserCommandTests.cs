using Explorer.API.Controllers.Administrator.Administration;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.API.Public.Administration;
using Explorer.Stakeholders.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Stakeholders.Tests.Integration.Administration;

[Collection("Sequential")]
public class UserCommandTests : BaseStakeholdersIntegrationTest
{
    public UserCommandTests(StakeholdersTestFactory factory) : base(factory) { }

    [Fact]
    public void Blocks()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
        
        // Act
        var result = ((ObjectResult)controller.Block(-21).Result)?.Value as UserDto;
        
        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-21);
        result.IsActive.ShouldBeFalse();
        
        // Assert - Database
        var storedEntity = dbContext.Users.FirstOrDefault(i => i.Id == -21);
        storedEntity.ShouldNotBeNull();
        storedEntity.IsActive.ShouldBeFalse();
    }
    
    [Fact]
    public void Block_fails_invalid_id()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        
        // Act
        var result = (ObjectResult)controller.Block(-1000).Result;
        
        // Assert
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(404);
    }

    private static UserManagmentController CreateController(IServiceScope scope)
    {
        return new UserManagmentController(scope.ServiceProvider.GetRequiredService<IUserManagmentService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }
    
}