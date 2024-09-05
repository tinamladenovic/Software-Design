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

public class TourRatingQueryTests : BaseToursIntegrationTest
{
    public TourRatingQueryTests(ToursTestFactory factory) : base(factory)
    {
    }
    [Fact]
    public void Retrieves_all()
    {
        //Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        //Act
        var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<TourRatingDto>;


        //Asert
        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(3);
        result.TotalCount.ShouldBe(3);

    }

    [Fact]
    public void Retrieves_Grades_For_Tour()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        // Act
        var result = controller.GetGradesForTour(1);

        // Assert
        result.ShouldNotBeNull();
        result.Count.ShouldBe(1);
        result[0].ShouldBe(5);
    }

    private static TourRatingController CreateController(IServiceScope scope)
    {
        return new TourRatingController(scope.ServiceProvider.GetRequiredService<ITourRatingService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }
}