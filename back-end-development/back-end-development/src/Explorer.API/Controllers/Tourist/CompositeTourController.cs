using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Tourist;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Route("api/compositetour")]
    public class CompositeTourController : BaseApiController
    {
        private readonly ICompositeTourService _compositeTourService;

        public CompositeTourController(ICompositeTourService compositeTourService)
        {
            _compositeTourService = compositeTourService;
        }

        [HttpGet("touristscompositetours")]
        public ActionResult<PagedResult<CompositeTourDto>> GetAllCompositeTours([FromQuery] int touristId, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _compositeTourService.GetByTouristId(touristId, page, pageSize);

            
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<CompositeTourDto> Create([FromBody] CompositeTourDto compositeTour)
        {
            var result = _compositeTourService.Create(compositeTour);
            return CreateResponse(result);
        }

        [HttpGet("getCheckpoints/{compositeTourId:int}")]

        public ActionResult<PagedResult<CheckpointDto>> GetAllByTourId([FromQuery] int page, [FromQuery] int pageSize, int compositeTourId)
        {
            var result = _compositeTourService.GetCheckpoints(page, pageSize, compositeTourId);
            return CreateResponse(result);
        }
    }
}
