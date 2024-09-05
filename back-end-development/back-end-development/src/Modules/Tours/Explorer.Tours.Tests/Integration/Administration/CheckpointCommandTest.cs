using Explorer.API.Controllers.Author;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Xml.Linq;

namespace Explorer.Tours.Tests.Integration.Administration;

[Collection("Sequential")]
public class CheckpointCommandTest : BaseToursIntegrationTest
{

    public CheckpointCommandTest(ToursTestFactory factory) : base(factory) { }
    
    [Fact]
    public void Creates()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
        var newEntity = new CheckpointDto(1, "novisad", "grad", "slika", 45.393251M, 20.391165M, -124, new PublicRequestDto(RequestStatusDto.Pending, null));

        // Act   
        controller.AddCheckPointOnTour(-124, newEntity);

        // Assert - Database
        var tour = dbContext.Checkpoints.Where(p => p.TourId == newEntity.TourId).ToList();

        tour.ShouldNotBeNull();
    }
    

    private static TourController CreateController(IServiceScope scope)
    {
        return new TourController(scope.ServiceProvider.GetRequiredService<ITourService>(), scope.ServiceProvider.GetRequiredService<ICheckpointService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }
}
