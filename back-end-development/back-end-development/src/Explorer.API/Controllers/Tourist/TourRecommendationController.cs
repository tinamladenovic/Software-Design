using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.API.Public.TourExecution;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.Core.Recommendation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/recommendation")]
    public class TourRecommendationController : BaseApiController
    {
        private readonly ITourExecutionService _tourExecutionService;
        private readonly ITourPreferencesService _tourPreferencesService;
        private readonly ITourRatingService _tourRatingService;
        private readonly ITourService _tourService;
        private TourRecommender _tourRecommender; 
        private readonly IActiveToursRecommender _activeToursRecommender;

        public TourRecommendationController(ITourExecutionService tourExecutionService, ITourPreferencesService tourPreferencesService, ITourRatingService tourRatingService, 
            ITourService tourService, IActiveToursRecommender activeToursRecommender)
        {
            _tourExecutionService = tourExecutionService;
            _tourPreferencesService = tourPreferencesService;
            _tourRatingService = tourRatingService;
            _tourService = tourService;
            _tourRecommender = new TourRecommender(_tourService, _tourPreferencesService, _tourRatingService, _tourExecutionService);
            _activeToursRecommender = activeToursRecommender;
        }

        [HttpGet]
        public ActionResult<List<TourDto>> GetRecommendedTours()
        {
            var result = _tourRecommender.GetRecommendedTours(ClaimsPrincipalExtensions.PersonId(User));
            return CreateResponse(result);
        }

        [HttpGet("activeTours")]
        public ActionResult<PagedResult<TourDto>> GetRecommendedActiveTours()
        {
            var result = _activeToursRecommender.GetRecommendedTours(ClaimsPrincipalExtensions.PersonId(User));
            return CreateResponse(result);
        }
    }
}
