using Explorer.Encounters.API.Dtos;
using Explorer.Payments.API.Public.ShoppingCart;
using Explorer.Tours.API.Public.Tourist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.ShoppingCart
{
    [Authorize(Policy = "touristPolicy")]
    [Microsoft.AspNetCore.Mvc.Route("api/tourist/shoppingCart/tourStatistics")]
    public class TourStatisticsController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly ITourRatingService _tourRatingService;

        public TourStatisticsController(IOrderService orderService, ITourRatingService tourRatingService)
        {
            _orderService = orderService;
            _tourRatingService = tourRatingService;
        }

        [HttpGet("orderCount/{tourId:long}")]
        public ActionResult<int> GetOrderCount(long tourId)
        {
            var result = _orderService.GetOrderCount(tourId);
            return CreateResponse(result);
        }

        [HttpGet("ratingCount/{tourId:long}")]
        public ActionResult<int> GetRatingCount(long tourId)
        {
            var result = _tourRatingService.GetRatingsCountForPastWeek(tourId);
            return CreateResponse(result);
        }

        [HttpGet("averageRating/{tourId:long}")]
        public ActionResult<double> GetAverageRating(long tourId)
        {
            var result = _tourRatingService.GetAverageRatingForPastWeek(tourId);
            return CreateResponse(result);
        }
    }
}
