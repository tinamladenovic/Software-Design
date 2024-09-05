namespace Explorer.Tours.Core.Domain.RepositoryInterfaces;

public interface ITourCouponRepository
{
    public void Create(TourCoupon coupon);

    public void Remove(TourCoupon coupon);

    public void Update(TourCoupon coupon);
    public TourCoupon GetByHash(string couponHash);
}
