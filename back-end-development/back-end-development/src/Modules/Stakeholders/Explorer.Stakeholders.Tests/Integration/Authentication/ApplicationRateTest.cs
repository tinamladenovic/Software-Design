namespace Explorer.Stakeholders.Tests.Integration.Authentication
{
    using Explorer.API.Controllers.Administrator.Administration;
    using Explorer.BuildingBlocks.Core.UseCases;
    using Explorer.Stakeholders.API.Dtos;
    using Explorer.Stakeholders.API.Public;
    using Explorer.Stakeholders.Infrastructure.Database;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Shouldly;

    [Collection("Sequential")]
    public class ApplicationRateTest : BaseStakeholdersIntegrationTest
    {
        public ApplicationRateTest(StakeholdersTestFactory factory) : base(factory) { }

        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<ApplicationRateDto>;

            // Assert/*
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(2);
            result.TotalCount.ShouldBe(2);
        }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();

            var controller = CreateController(scope);

            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var newEntity = new ApplicationRateDto
            {
                Comment = "Komentar",
                Rate = 1,
                CreationTime = new DateTime(),
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as ApplicationRateDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Rate.ShouldNotBe(0);
            result.PersonId.ShouldBe(newEntity.PersonId);

            // Assert - Database
            var storedEntity = dbContext.ApplicationRate.FirstOrDefault(i => i.Comment == newEntity.Comment);
            storedEntity.ShouldNotBeNull();
        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new ApplicationRateDto
            {
                Rate = 0
            };

            // Act
            var result = (ObjectResult)controller.Create(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }


        private static ApplicationRateController CreateController(IServiceScope scope)
        {
            return new ApplicationRateController(scope.ServiceProvider.GetRequiredService<IApplicationRateService>())
            {
                ControllerContext = BuildContext("-13")
            };
        }
    }
}
