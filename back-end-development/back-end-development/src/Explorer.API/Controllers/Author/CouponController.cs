using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos.Coupon;
using Explorer.Tours.API.Public.Author;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author;

[Route("api/author/coupons")]
public class CouponController : BaseApiController
{
	private readonly ICouponService _couponService;
 
	public CouponController(ICouponService couponService)
	{
		_couponService = couponService;
	}

    [HttpPost("createCoupon")]
    public ActionResult<CouponDto> CreateCoupon([FromBody] CouponRequest couponDTO)
    {
		var response = CreateResponse(_couponService.CreateCoupon(User.UserId(), couponDTO.tourId, couponDTO));
		return response;
    }

	[HttpDelete("deleteCoupon")]
    public async Task<ActionResult> DeleteCoupon(string CouponHash)
    {
        var result = _couponService.DeleteCoupon(User.UserId(), CouponHash);
        var response = CreateResponse(result);
        return response;
    }

    [HttpPut("updateCoupon")]
    public async Task<ActionResult> UpdateCoupon([FromBody] CouponRequest couponDTO, string couponHash)
    {
        var result = _couponService.UpdateCoupon(User.UserId(), couponDTO, couponHash);
        var response = CreateResponse(result);
        return response;
    }



    [HttpPost("createGiftCoupon")]
    public ActionResult<CouponDto> CreateGiftCoupon([FromBody] CouponRequest couponDTO)
    {
        var response = CreateResponse(_couponService.CreateGiftCoupon(couponDTO.tourId, couponDTO));
        return response;
    }



}
