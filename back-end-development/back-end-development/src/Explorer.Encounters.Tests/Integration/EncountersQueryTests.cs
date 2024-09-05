using Explorer.API.Controllers.Administrator.Administration;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.API.Controllers.Tourist.Execution;
using Shouldly;

namespace Explorer.Encounters.Tests.Integration
{
    [Collection("Sequential")]
    public class EncountersQueryTests : BaseEncountersIntegrationTest
    {
        public EncountersQueryTests(EncountersTestFactory factory) : base(factory) { }

        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateEncounterController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<EncounterDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(6);
            result.TotalCount.ShouldBe(6);
        }

        [Fact]
        public void Retrieves_all_active()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateExecutionController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllActive().Result)?.Value as PagedResult<EncounterDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(3);
            result.TotalCount.ShouldBe(3);
        }

        private static EncounterController CreateEncounterController(IServiceScope scope)
        {
            return new EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }

        private static EncounterExecutionController CreateExecutionController(IServiceScope scope)
        {
            return new EncounterExecutionController(scope.ServiceProvider.GetRequiredService<IEncounterExecutionService>(), 
                                      scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildContext("-21")
            };
        }
    }
}
