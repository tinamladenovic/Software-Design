using Explorer.API.Controllers.Author;
using Explorer.Tours.API.Dtos.Coupon;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shouldly;
using System.Security.Claims;

namespace Explorer.Tours.Tests.Integration.Author;

[Collection("Sequential")]
public class CouponCommandTest : BaseToursIntegrationTest
{
	public CouponCommandTest(ToursTestFactory factory) : base(factory)
	{

	}

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim("id", "2"),
        }, "TestAuthentication"));


        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };

        var newEntity = new CouponRequest
        {
            ExpirationDate= DateTime.UtcNow.AddDays(1),
            DiscountPercentage = 100.0
        };

        var taskResult = controller.CreateCoupon(newEntity);
        var actionResult = taskResult.Result as ObjectResult;

        Assert.NotNull(actionResult); 

        var couponResponse = actionResult?.Value as CouponDto;
        Assert.NotNull(couponResponse); 

        var resultString = couponResponse?.CouponHash; 
        Assert.IsType<string>(resultString);

    }

    [Fact]
    public async void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
        var dbSet = dbContext.Set<TourCoupon>();
        var controller = CreateController(scope);

        string couponHash = "D32HFHSH";
        var tourCoupon = new TourCoupon(1533, couponHash , 12.5, DateTime.Now.AddDays(1).ToUniversalTime(), 1, 2, false, true);
        dbSet.Add(tourCoupon);
        dbContext.SaveChanges();

        Claim userId = new Claim("id", "2");
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {userId}));

        controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };

        DateTime date = DateTime.Now.AddDays(2).ToUniversalTime();

        var newEntity = new CouponRequest
        {
            ExpirationDate = date,
            DiscountPercentage = 90.0
        };

        var response = controller.UpdateCoupon(newEntity, couponHash);

        var storedEntity = dbContext.Coupons.FirstOrDefault(i => i.CouponHash == couponHash);

        Assert.NotNull(storedEntity);
        Assert.NotNull(response);

        Assert.Equal(storedEntity.DiscountPercentage, newEntity.DiscountPercentage);
        Assert.Equal(storedEntity.DiscountExpiration, newEntity.ExpirationDate);

    }

    [Fact]
    public async void Delete()
    {
        var scope = Factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
        var dbSet = dbContext.Set<TourCoupon>();
        var controller = CreateController(scope);

        Claim userId = new Claim("id", "2");
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { userId }));

        controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };

        string couponHash = "D32QFCSH";
        var tourCoupon = new TourCoupon(11, couponHash, 12.5, DateTime.Now.AddDays(1).ToUniversalTime(), 1, 2, false, true);
        dbSet.Add(tourCoupon);
        dbContext.SaveChanges();

        var response = controller.DeleteCoupon(couponHash);

        var result = dbSet.Where(c => c.CouponHash == couponHash).FirstOrDefault();

        Assert.Null(result);

    }

    private static CouponController CreateController(IServiceScope scope)
    {
        return new CouponController(scope.ServiceProvider.GetRequiredService<ICouponService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }

}
