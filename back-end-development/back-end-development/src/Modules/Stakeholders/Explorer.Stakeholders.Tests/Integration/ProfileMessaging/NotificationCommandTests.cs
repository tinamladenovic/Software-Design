using Explorer.API.Controllers.Tourist;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Tests.Integration.ProfileMessaging
{
    [Collection("Sequential")]
    public class NotificationCommandTests : BaseStakeholdersIntegrationTest
    {
        public NotificationCommandTests(StakeholdersTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var newEntity = new NotificationDto
            {
                SenderId = -11,
                ReceiverId = -22,
                Message = "nebitno3",
                IsRead = false
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as NotificationDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.SenderId.ShouldBe(newEntity.SenderId);
            result.ReceiverId.ShouldBe(newEntity.ReceiverId);

            // Assert - Database
            var storedEntity = dbContext.Notifications.FirstOrDefault(i => i.SenderId == newEntity.SenderId && i.ReceiverId == newEntity.ReceiverId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var newEntity = new NotificationDto
            {
                SenderId = -280,
                ReceiverId = 60,
                Message = "greska",
                IsRead = true
            };

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

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
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var updatedEntity = new NotificationDto
            {
                Id = -1,
                SenderId = -21,
                ReceiverId = -11,
                Message = "nebitno",
                IsRead = false
            };

            // Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as NotificationDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-1);
            result.SenderId.ShouldBe(updatedEntity.SenderId);
            result.ReceiverId.ShouldBe(updatedEntity.ReceiverId);

            // Assert - Database
            var storedEntity = dbContext.Notifications.FirstOrDefault(i => i.IsRead == false && i.Id == -1);
            storedEntity.ShouldNotBeNull();
            storedEntity.IsRead.ShouldBe(updatedEntity.IsRead);
            var oldEntity = dbContext.Notifications.FirstOrDefault(i => i.IsRead == true && i.Id==-1);
            oldEntity.ShouldBeNull();
        }

        [Fact]
        public void Update_fails_invalid_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new NotificationDto
            {
                Id = -1,
                SenderId = -211,
                ReceiverId = -111,
                Message = "nebitno",
                IsRead = false
            };

            // Act
            var result = (ObjectResult)controller.Update(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);
        }

        private static NotificationController CreateController(IServiceScope scope)
        {
            return new NotificationController(scope.ServiceProvider.GetRequiredService<INotificationService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
