using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Statistic;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Route("api/tourstatistic")]
    public class TourStatisticController : BaseApiController
    {
        private readonly ITourStatisticService _tourStatisticService;

        public TourStatisticController(ITourStatisticService tourStatisticService)
        {
            _tourStatisticService = tourStatisticService;
        }

        //TODO: implementacija metoda


        [HttpGet("singletourstatistic")]
        public ActionResult<SingleTourStatisticDto> GetSingleTourStatistic(int tourId)
        {
            var result = _tourStatisticService.CalculateStatistic(tourId);
            return CreateResponse(result);
        }




    }
}
