using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public.PaymentRecord;
using Explorer.Payments.API.Public.TourBundle;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Coupon;
using Explorer.Tours.API.Public.Author;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Microsoft.AspNetCore.Mvc.Route("api/tourist/tourBundle")]
    public class TourBundleTouristController : BaseApiController
    {
        private readonly IPaymentRecordService _paymentRecordService;
        private readonly ITourBundleService _tourBundleService;
        private readonly ICouponService _couponService;
        public TourBundleTouristController(IPaymentRecordService paymentRecordService, ITourBundleService tourBundleService, ICouponService couponService)
        {
            _paymentRecordService = paymentRecordService;
            _tourBundleService = tourBundleService;
            _couponService = couponService;
        }

        [HttpGet]
        public ActionResult<PagedResult<TourBundleDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourBundleService.GetAll(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("{tourId:int}")]
        public ActionResult<PagedResult<TourBundleDto>> GetByTour([FromQuery] int page, [FromQuery] int pageSize, int tourId)
        {
            var result = _tourBundleService.GetByTour(tourId, page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost("purchase/{bundleId:int}")]
        public ActionResult<PaymentRecordDto> Create(int bundleId, [FromBody] double amount)
        {
            long touristId = ClaimsPrincipalExtensions.PersonId(User);
            var result = _paymentRecordService.CreateRecord(touristId, bundleId,  amount);
            var bundle = _tourBundleService.Get(bundleId);
            if (bundle.IsSuccess != false && bundle.Value != null)
            {
                foreach (TourStatusDto dto in bundle.Value.Tours)
                {
                    var couponRequest = new CouponRequest();
                    couponRequest.DiscountPercentage = 10;
                    couponRequest.ExpirationDate = DateTime.Now.AddDays(14).ToUniversalTime();
                    _couponService.CreateCoupon((int)touristId, (int)dto.TourId, couponRequest);
                }

                return CreateResponse(result);
            }

            return CreateResponse(bundle);

        }
    }
}
