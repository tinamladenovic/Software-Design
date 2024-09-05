using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories;

public class TourCouponRepository : ITourCouponRepository
{
    private readonly ToursContext _context;
    private readonly DbSet<TourCoupon> _coupons;

    public TourCouponRepository(ToursContext context)
    {
        _context = context;
        _coupons = _context.Set<TourCoupon>();
    }

    public void Create(TourCoupon coupon)
    {
        try
        {
            _coupons.Add(coupon);
            _context.SaveChanges();
        }catch(Exception ex)
        {
            throw new Exception(ex + "Unable to save coupon!");
        }
    }

    public TourCoupon GetByHash(string couponHash)
    {
        try
        {
            return _coupons.Where(c => c.CouponHash == couponHash).FirstOrDefault();
        }
        catch (Exception ex)
        {
            throw new Exception(ex + "Unable to find coupon!");
        }
    }

    public void Remove(TourCoupon coupon)
    {
        try
        {
            _coupons.Remove(coupon);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex + "Unable to find delete!");
        }
    }

    public void Update(TourCoupon coupon)
    {
        try
        {
            _coupons.Update(coupon);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex + "Unable to update!");
        }
    }
}
