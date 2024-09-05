using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Tourist;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/tourRating")]
    public class TourRatingController : BaseApiController
    {
        private readonly ITourRatingService _tourRatingService;

        public TourRatingController(ITourRatingService tourRatingService)
        {
            _tourRatingService = tourRatingService;
        }

        [HttpGet]
        public ActionResult<PagedResult<TourRatingDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourRatingService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<TourRatingDto> Create([FromBody] TourRatingDto tourRating)
        {
            tourRating.TourId = ClaimsPrincipalExtensions.PersonId(User);
            var result = _tourRatingService.Create(tourRating);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<TourRatingDto> Update([FromBody] TourRatingDto tourRating)
        {
            tourRating.TourId = ClaimsPrincipalExtensions.PersonId(User);
            var result = _tourRatingService.Update(tourRating);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _tourRatingService.Delete(id);
            return CreateResponse(result);
        }

        [HttpGet("GetGradesForTour/{tourId:int}")]
        public List<int> GetGradesForTour(long tourId)
        {
            var result = _tourRatingService.GetAllGradesForTour(tourId);
            return result;
        }

        [HttpGet("GetAverageGradeForTour/{tourId:int}")]
        public float GetAverageGradeForTour(long tourId)
        {
            float result = 0;
            result = _tourRatingService.GetAverageGradeForTour(tourId);
            return result;
        }
    }
}
