using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.UseCases.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    //[Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/tourSearch")]
    public class TourSearchController : BaseApiController
    {
        private readonly ICheckpointService _checkPointService;
        public TourSearchController(ICheckpointService checkPointService) 
        {
            _checkPointService = checkPointService;
        }


        [HttpGet]
        public async Task<ActionResult<TourDto>> GetAllToursInRange([FromQuery] TourSearchDto tourSearch)
        {
            var result = await _checkPointService.GetToursInRange(tourSearch);

            if (result.IsSuccess)
            {
                return Ok(result.Value); 
            }
            else
            {
                return BadRequest(result.Errors[1]); // Handle the case where the result is not successful
            }
        }



    }
}
