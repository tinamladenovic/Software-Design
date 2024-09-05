using Explorer.API.Controllers.Tourist.Club;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Club;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.TouristClub;
[Collection("Sequential")]
public class TouristClubCommandTest : BaseToursIntegrationTest
{
    public TouristClubCommandTest(ToursTestFactory factory) : base(factory)
    {
    }
    [Fact] //naznaka da se radi o automatskom testu
    public void Creates()
    {
        //Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
        var newEntity = new TouristClubDto
        {
            Id = -11,
            ClubName = "test",
            Description = "test",
            Image = "slika.jpg",
            OwnerId = -21
        };

        //Act 
        var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as TouristClubDto;

        // Assert - Response 
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.ClubName.ShouldBe(newEntity.ClubName);
        result.Description.ShouldBe(newEntity.Description);

        // Assert - Database
        var storedEntity = dbContext.TouristClubs.FirstOrDefault(tc => tc.ClubName == newEntity.ClubName);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);

    }
    [Fact]
    public void Create_fails_invalid_data()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var updatedEntity = new TouristClubDto
        {
            Description = "Test"
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
        var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
        var updatedEntity = new TouristClubDto
        {
            Id = 20,
            ClubName = "Club 1234",
            Description = "description 1234",
            Image = "asd",
            OwnerId = -21,
        };

        // Act
        var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as TouristClubDto;

        // Assert - Response
        result.ShouldNotBeNull();
        result.Id.ShouldBe(20);
        result.ClubName.ShouldBe(updatedEntity.ClubName);
        result.Description.ShouldBe(updatedEntity.Description);

        // Assert - Database
        var storedEntity = dbContext.TouristClubs.FirstOrDefault(i => i.ClubName == "Club 1234");
        storedEntity.ShouldNotBeNull();
        storedEntity.Description.ShouldBe(updatedEntity.Description);
        var oldEntity = dbContext.TouristClubs.FirstOrDefault(i => i.ClubName == "Club 123");
        oldEntity.ShouldBeNull();
    }

    [Fact]
    public void Update_fails_invalid_id()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var updatedEntity = new TouristClubDto
        {
            Id = -1000,
            ClubName = "Test"
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
        var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

        // Act
        var result = (OkResult)controller.Delete(10);

        // Assert - Response
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);

        // Assert - Database
        var storedCourse = dbContext.TouristClubs.FirstOrDefault(i => i.Id == 3);
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

    private static TouristClubController CreateController(IServiceScope scope)
    {
        return new TouristClubController(scope.ServiceProvider.GetRequiredService<ITouristClubService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }
}
