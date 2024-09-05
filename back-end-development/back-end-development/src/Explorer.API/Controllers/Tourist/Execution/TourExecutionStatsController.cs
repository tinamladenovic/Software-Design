using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Public.TourExecution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Execution
{
    [Microsoft.AspNetCore.Mvc.Route("api/tourist/execution/tourExecutionStats")]
    public class TourExecutionStatsController : BaseApiController
    {
        private readonly ITourExecutionStatsService _tourExecutionStatsService;

        public TourExecutionStatsController(ITourExecutionStatsService tourExecutionStatsService)
        {
            _tourExecutionStatsService = tourExecutionStatsService;
        }

        [HttpGet("totalCount")]
        public ActionResult<int> GetCompletedTourExecutionCount()
        {
            var result = _tourExecutionStatsService.GetCompletedTourExecutionCount();
            var retVal = CreateResponse(result);
            return retVal;
        }

        [HttpGet("totalDistance")]
        public ActionResult<double> GetTotalCoveredDistance() 
        {             
            var result = _tourExecutionStatsService.GetTotalCoveredDistance();
            return CreateResponse(result);
        }

        [Authorize(Policy = "touristPolicy")]
        [HttpGet("touristCount")]
        public ActionResult<int> GetTouristCompletedTourExecutionCount()
        {
            var result = _tourExecutionStatsService.GetTouristCompletedTourExecutionCount(ClaimsPrincipalExtensions.PersonId(User));
            return CreateResponse(result);
        }

        [Authorize(Policy = "touristPolicy")]
        [HttpGet("touristDistance")]
        public ActionResult<double> GetTouristTotalCoveredDistance()
        {
            var result = _tourExecutionStatsService.GetTouristTotalCoveredDistance(ClaimsPrincipalExtensions.PersonId(User));
            return CreateResponse(result);
        }
    }
}
