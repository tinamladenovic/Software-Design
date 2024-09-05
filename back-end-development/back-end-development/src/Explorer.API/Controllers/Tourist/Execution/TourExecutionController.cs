using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.API.Public.TourExecution;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.Core.Domain.TourExecutions;
using Explorer.Tours.Core.Recommendation;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Execution
{

    [Authorize(Policy = "touristPolicy")]
    [Microsoft.AspNetCore.Mvc.Route("api/tourist/execution/tourExecution")]
    public class TourExecutionController : BaseApiController
    {
        private readonly ITourExecutionService _tourExecutionService;
        private readonly ITourPreferencesService _tourPreferencesService;
        private readonly ITourRatingService _tourRatingService;
        private readonly ITourService _tourService;
        private TourRecommender _tourRecommender;

        public TourExecutionController(ITourExecutionService tourExecutionService, ITourPreferencesService tourPreferencesService, ITourRatingService tourRatingService,
            ITourService tourService)
        {
            _tourExecutionService = tourExecutionService;
            _tourPreferencesService = tourPreferencesService;
            _tourRatingService = tourRatingService;
            _tourService = tourService;
            _tourRecommender = new TourRecommender(_tourService, _tourPreferencesService, _tourRatingService, _tourExecutionService);
        }

        [HttpGet("{id:int}")]
        public ActionResult<TourExecutionDto> Get(int id)
        {
            var result = _tourExecutionService.Get(id);
            return CreateResponse(result);
        }

        [HttpPost()]
        public ActionResult<TourExecutionDto> Create([FromBody] int tourId)
        {
            var result = _tourExecutionService.Create(tourId, ClaimsPrincipalExtensions.PersonId(User));
            return CreateResponse(result);
        }

        [HttpPost("compositetour")]
        public ActionResult<TourExecutionDto> CreateForcompositeTour([FromBody] int tourId)
        {
            var result = _tourExecutionService.CreateForCompositeTour(tourId, ClaimsPrincipalExtensions.PersonId(User));
            return CreateResponse(result);
        }

        [HttpPatch("{id:int}/{checkpointId:int}")]
        public ActionResult<TourExecutionDto> UpdateProgress(int id, int checkpointId, [FromBody] TourExecutionUpdateDto currentPosition) 
        {
            var result = _tourExecutionService.UpdateProgress(id, checkpointId, ClaimsPrincipalExtensions.PersonId(User), currentPosition);
            return CreateResponse(result);
        }

        [HttpPatch("abandon")]
        public ActionResult<TourExecutionDto> Abandon([FromBody] int id)
        {
            var result = _tourExecutionService.Abandon(id, ClaimsPrincipalExtensions.PersonId(User));
            return CreateResponse(result);
        }

        [HttpGet("GetRecomendedForTourAndUser/{tourId:int}/{userId:int}")]
        public ActionResult<List<TourDto>> GetRecomendedForTourAndUser(long tourId,long userId)
        {
            List<TourDto> listForSending = _tourExecutionService.GetRecomendedForTourAndUser(tourId,userId);
            Result<PagedResult<TourDto>> result = _tourRecommender.RearangeTours(listForSending, userId).Value;
            return CreateResponse(result);
        }
    }
}