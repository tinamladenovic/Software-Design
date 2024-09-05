using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Internal;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Internal;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos.Coupon;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Author;

public class CouponService : BaseService<CouponDto,TourCoupon>, ICouponService, IInternalCouponService
{
	private readonly ITourCouponRepository _tourCouponRepository;
	private readonly IMapper _mapper;
	private readonly ITourRepository _tourRepository;

    public CouponService(ITourCouponRepository tourCouponRepository,
						IMapper mapper,
                        ITourRepository tourRepository) : base(mapper)
	{

		_tourCouponRepository = tourCouponRepository;
		_mapper = mapper;
        _tourRepository = tourRepository;
	}

	public Result<CouponDto> CreateCoupon(int userId,int? tourId,CouponRequest coupon)
	{
		try
		{

            if (coupon.ExpirationDate < DateTime.Now)
                return Result.Fail(FailureCode.InvalidArgument).WithError("Invalid Date");

            var tourCoupon = new TourCoupon(coupon.DiscountPercentage,
										coupon.ExpirationDate,
										null,
										userId);

			tourCoupon.IsApplicableToAllUserTours = tourId == null;
			tourCoupon.ApplicableTourId = tourId;

			_tourCouponRepository.Create(tourCoupon);
			return MapToDto(tourCoupon);

		}catch(Exception ex)
		{
			throw new Exception(ex.ToString());
		}
	}

	public Result<CouponDto>CreateGiftCoupon(int? tourId, CouponRequest coupon)
	{
		long authorId = _tourRepository.GetRandomTourAuthorByTour();
        try
        {

            if (coupon.ExpirationDate < DateTime.Now)
                return Result.Fail(FailureCode.InvalidArgument).WithError("Invalid Date");

            var tourCoupon = new TourCoupon(coupon.DiscountPercentage,
                                        coupon.ExpirationDate,
                                        null,
                                        Convert.ToInt32(authorId));

            tourCoupon.IsApplicableToAllUserTours = tourId == null;
            tourCoupon.ApplicableTourId = tourId;

            _tourCouponRepository.Create(tourCoupon);
            return MapToDto(tourCoupon);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }

    }

	public int GetTourByCouponHash(string couponHash)
	{
        CouponDto coupon = GetByHash(couponHash);
		return coupon.TourId;

    }

	public double GetDiscounyByCouponHash(string couponHash)
	{
        CouponDto coupon = GetByHash(couponHash);
		return coupon.DiscountProcentage;
    }

    public bool CheckIfIsApplicableToAll(string couponHash)
	{
		CouponDto coupon = GetByHash(couponHash);
		if (coupon.IsApplicableToAllUserTours == true)
			return true;
		else return false;

    }


    public void SetCouponToInvalid(string couponHash)
	{
        TourCoupon tourCoupon = _tourCouponRepository.GetByHash(couponHash);
		if (tourCoupon.IsValid is false)
			return;
		tourCoupon.IsValid = false;
		_tourCouponRepository.Update(tourCoupon);
    }

    public Result DeleteCoupon(int userId, string couponHash)
    {
        TourCoupon tourCoupon = _tourCouponRepository.GetByHash(couponHash);

        if (tourCoupon == null)
            return Result.Fail(FailureCode.NotFound).WithError("Coupon not found.");

        if (tourCoupon.CouponIssuerId != userId)
            return Result.Fail(FailureCode.Forbidden).WithError("User is not authorized to delete this coupon.");

		try
		{
            _tourCouponRepository.Remove(tourCoupon);
        }catch (Exception ex)
		{
			return Result.Fail(ex.ToString());
		}

        return Result.Ok();
    }


	public bool IsCoupnValid(string couponHash)
	{
        TourCoupon tourCoupon = _tourCouponRepository.GetByHash(couponHash);
		return (tourCoupon != null &&
				tourCoupon.IsValid == true &&
				tourCoupon.DiscountExpiration > DateTime.Now.ToLocalTime()) ? true : false;
    }


    public Result UpdateCoupon(int userId, CouponRequest coupon, string couponHash)
	{
        TourCoupon tourCoupon = _tourCouponRepository.GetByHash(couponHash);

        if (tourCoupon == null)
            return Result.Fail("Coupon not found.");

        if (tourCoupon.CouponIssuerId != userId)
            return Result.Fail("User is not authorized to delete this coupon.");

		if(coupon.ExpirationDate < DateTime.Now)
            return Result.Fail("Invalid Date");

		tourCoupon.Update(coupon.ExpirationDate, coupon.DiscountPercentage);

		try
		{
			_tourCouponRepository.Update(tourCoupon);
            return Result.Ok();
        }
        catch(Exception ex)
		{
            return Result.Fail(ex.ToString());
        }
    }

	public CouponDto GetByHash(string couponHash) 
	{
		var TourCoupon = _tourCouponRepository.GetByHash(couponHash);
		return MapToDto(TourCoupon);
	}

    public bool CheckIfAutorApplies(long id, string couponHash)
    {
        var tour = _tourRepository.GetById(id);
		var coupon = GetByHash(couponHash);

		if (tour.AuthorId == coupon.UserId)
			return true;

		return false;
    }
}
