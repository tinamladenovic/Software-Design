using Explorer.Tours.API.Dtos.Coupon;
using FluentResults;

namespace Explorer.Tours.API.Public.Author;

public interface ICouponService
{
    public Result<CouponDto> CreateCoupon(int userId, int? tourId, CouponRequest coupon);
    public Result<CouponDto> CreateGiftCoupon(int? tourId, CouponRequest coupon);

    public Result DeleteCoupon(int userId, string CouponHash);
    public CouponDto GetByHash(string couponHash);
    public bool IsCoupnValid(string couponHash);
    public Result UpdateCoupon(int userId, CouponRequest coupon, string couponHash);
    
}
