namespace Explorer.Tours.API.Dtos.Coupon;

public class CouponDto
{
    public int TourId { get; set; }
    public int UserId { get; set; }
    public double DiscountProcentage { get; set; }
    public bool IsApplicableToAllUserTours { get; set; }
    public string CouponHash { get; set; }
}
