using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Leaderboards;
using Explorer.Tours.API.Public.TourExecution;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Leaderboards
{
    [Microsoft.AspNetCore.Mvc.Route("api/tourist/leaderboards/tourExecution")]
    public class TourExecutionLeaderboardController : BaseApiController
    {
        private readonly ITourExecutionStatsService _tourExecutionStatsService;

        public TourExecutionLeaderboardController(ITourExecutionStatsService tourExecutionStatsService)
        {
            _tourExecutionStatsService = tourExecutionStatsService;
        }

        [HttpGet("currentMonth/completedTours")]
        public ActionResult<PagedResult<TouristCompletedToursDto>> GetTouristsRankedByCompletedToursCurrentMonth()
        {
            var result = _tourExecutionStatsService.GetTouristsRankedByCompletedToursThisMonth(0, 0);
            return CreateResponse(result);
        }

        [HttpGet("currentMonth/coveredDistance")]
        public ActionResult<PagedResult<TouristCoveredDistanceDto>> GetTouristsRankedByCoveredDistanceCurrentMonth()
        {
            var result = _tourExecutionStatsService.GetTouristsRankedByCoveredDistanceThisMonth(0, 0);
            return CreateResponse(result);
        }

        [HttpGet("currentWeek/completedTours")]
        public ActionResult<PagedResult<TouristCompletedToursDto>> GetTouristsRankedByCompletedToursCurrentWeek()
        {
            
            var result = _tourExecutionStatsService.GetTouristsRankedByCompletedToursThisWeek(0, 0);
            return CreateResponse(result);
        }

        [HttpGet("currentWeek/coveredDistance")]
        public ActionResult<PagedResult<TouristCoveredDistanceDto>> GetTouristsRankedByCoveredDistanceCurrentWeek()
        {
            var result = _tourExecutionStatsService.GetTouristsRankedByCoveredDistanceThisWeek(0, 0);
            return CreateResponse(result);
        }
    }
}
