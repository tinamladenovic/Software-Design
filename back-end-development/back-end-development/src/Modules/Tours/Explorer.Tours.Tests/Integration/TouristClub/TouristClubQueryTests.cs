using Explorer.API.Controllers.Administrator.Administration;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Explorer.API.Controllers.Tourist.Club;
using Explorer.Tours.API.Public.Club;

namespace Explorer.Tours.Tests.Integration.TouristClub;
[Collection("Sequential")]
public class TouristClubQueryTests : BaseToursIntegrationTest
{
    public TouristClubQueryTests(ToursTestFactory factory) : base(factory)
    {
    }
    [Fact]
    public void Retrieves_all()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        // Act
        var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<TouristClubDto>;

        // Assert
        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(3);
        result.TotalCount.ShouldBe(3);
    }
    private static TouristClubController CreateController(IServiceScope scope)
    {
        return new TouristClubController(scope.ServiceProvider.GetRequiredService<ITouristClubService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }
}
