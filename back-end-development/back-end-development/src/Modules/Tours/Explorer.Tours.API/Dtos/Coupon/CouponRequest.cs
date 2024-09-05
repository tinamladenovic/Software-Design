namespace Explorer.Tours.API.Dtos.Coupon;

public class CouponRequest
{
    public DateTime ExpirationDate { get; set; }
    public double DiscountPercentage { get; set; }
    public int? tourId { get; set; }
}
