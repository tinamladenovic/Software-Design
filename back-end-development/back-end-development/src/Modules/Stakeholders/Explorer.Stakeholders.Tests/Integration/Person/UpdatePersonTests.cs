using Explorer.API.Controllers;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Explorer.Stakeholders.Tests.Integration.Person
{
    [Collection("Sequential")]
    public class UpdatePersonTests : BaseStakeholdersIntegrationTest
    {
        public UpdatePersonTests(StakeholdersTestFactory factory) : base(factory) { }


        [Fact]
        public void Get_Person()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            int id = -21;

            //Act
            var result = ((ObjectResult)controller.Get(id).Result)?.Value as UpdatePersonDTO;

            //Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-21);
        }

        [Fact]
        public void Person_Update()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            var claims = new List<Claim>
            {
                new Claim("personId", "-21"),
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "test"));

            controller.ControllerContext.HttpContext.User = user;

            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var updateEntity = new UpdatePersonDTO
            {
                Id = -21,
                UserId = -21,
                Name = "Test1",
                Surname = "Test2",
                Email = "test@gmail.com",
                Motto = "Ja sam test",
                Biography = "Vec citav zivot",
                Image = "123456.jpg"
            };

            var imageFileMock = new Mock<IFormFile>();
            imageFileMock.Setup(f => f.FileName).Returns("123456.jpg");
            imageFileMock.Setup(f => f.Length).Returns(1024);

            var headerDictionary = new HeaderDictionary();
            headerDictionary.Add("Content-Disposition", "form-data; name=\"image\"; filename=\"123456.jpg\"");

            imageFileMock.Setup(f => f.ContentDisposition).Returns("form-data; name=\"image\"; filename=\"123456.jpg\"");

            //Act
            var result = ((ObjectResult)controller.Update(updateEntity,imageFileMock.Object).Result)?.Value as UpdatePersonDTO;


            //Assert -Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-21);
            result.Name.ShouldBe(updateEntity.Name);
            result.Surname.ShouldBe(updateEntity.Surname);
            result.Email.ShouldBe(updateEntity.Email);
            result.Motto.ShouldBe(updateEntity.Motto);
            result.Biography.ShouldBe(updateEntity.Biography);
            result.Image.ShouldBe(updateEntity.Image);

            //Assert-Database
            var storedEntity = dbContext.People.FirstOrDefault(p => p.Name == "Test1");
            storedEntity.ShouldNotBeNull();
            storedEntity.Name.ShouldBe(updateEntity.Name);
            storedEntity.Motto.ShouldBe(updateEntity.Motto);
            var oldEntity = dbContext.People.FirstOrDefault(i => i.Name == "Pera");
            oldEntity.ShouldBeNull();
        }

        private static PersonController CreateController(IServiceScope scope)
        {
            return new PersonController(scope.ServiceProvider.GetRequiredService<IPersonService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
