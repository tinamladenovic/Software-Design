using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Core.Domain;

public class TourCoupon : Entity
{
    public string CouponHash { get; set; }
    public double DiscountPercentage { get; set; }
    public DateTime DiscountExpiration { get; set; }
    public int? ApplicableTourId { get; set; }
    public int CouponIssuerId { get; set; }
    public bool? IsApplicableToAllUserTours { get; set; } = false;
    public bool IsValid { get; set; } = false;

    public TourCoupon(double discountPercentage,
                      DateTime discountExpiration,
                      int? applicableTourId,
                      int couponIssuerId)
    {
        CouponHash = CreateRandomCouponHash();
        DiscountPercentage = discountPercentage;
        DiscountExpiration = discountExpiration;
        ApplicableTourId = applicableTourId;
        CouponIssuerId = couponIssuerId;
        IsValid = true;
    }

    public TourCoupon(long id,string couponHash, double discountPercentage, DateTime discountExpiration, int? applicableTourId, int couponIssuerId, bool? isApplicableToAllUserTours, bool isValid)
    {
        Id = id;
        CouponHash = couponHash;
        DiscountPercentage = discountPercentage;
        DiscountExpiration = discountExpiration;
        ApplicableTourId = applicableTourId;
        CouponIssuerId = couponIssuerId;
        IsApplicableToAllUserTours = isApplicableToAllUserTours;
        IsValid = isValid;
    }

    private string CreateRandomCouponHash()
    {
        Random random = new();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 8)
                         .Select(c => c[random.Next(chars.Length)]).ToArray());
    }

    public void Update(DateTime expirationDate, double discount)
    {
        DiscountExpiration = expirationDate;
        DiscountPercentage = discount;
    }

}
