using Explorer.API.Controllers.Tourist;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Tourist;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration.Tourist;
[Collection("Sequential")]

public class TourPreferencesQueryTests : BaseToursIntegrationTest
{
    public TourPreferencesQueryTests(ToursTestFactory factory) : base(factory)
    {
    }
    [Fact]
    public void Retrieves_all()
    {
        //Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        //Act
        var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<TourPreferencesDto>;


        //Asert
        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(2);
        result.TotalCount.ShouldBe(2);

    }

    private static TourPreferencesController CreateController(IServiceScope scope)
    {
        return new TourPreferencesController(scope.ServiceProvider.GetRequiredService<ITourPreferencesService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }
}
