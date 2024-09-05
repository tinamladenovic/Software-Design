using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.Core.UseCases.Tourist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/tourReview")]
    public class TourReviewController : BaseApiController
    {

        private readonly ITourReviewService _tourReviewService;

        public TourReviewController(ITourReviewService tourReviewService)
        {
            _tourReviewService = tourReviewService;
        }

        [HttpGet]
        public ActionResult<PagedResult<TourReviewDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourReviewService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<TourReviewDto> Create([FromBody] TourReviewDto tourReview)
        {
            var result = _tourReviewService.Create(tourReview);
            return CreateResponse(result);
        }



    }
}
