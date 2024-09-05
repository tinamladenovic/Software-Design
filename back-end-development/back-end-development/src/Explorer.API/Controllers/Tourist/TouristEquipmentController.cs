using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourism/touristEquipment")]
    public class TouristEquipmentController : BaseApiController
    {
        private readonly ITouristEquipmentService _touristEquipmentService;

        public TouristEquipmentController(ITouristEquipmentService touristEquipmentService)
        {
            _touristEquipmentService = touristEquipmentService;
        }

        [HttpGet]
        public ActionResult<PagedResult<TouristEquipmentDTO>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _touristEquipmentService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("{id:long}")]
        public ActionResult<PagedResult<EquipmentDto>> GetById([FromQuery] int page, [FromQuery] int pageSize, long id)
        {
            //return Response.Ok();
            var result = _touristEquipmentService.GetPagedById(page, pageSize, id);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<TouristEquipmentDTO> Create([FromBody] TouristEquipmentDTO touristEquipment)
        {
            var result = _touristEquipmentService.Create(touristEquipment);
            return CreateResponse(result);
        }

        [HttpDelete("{id:long}")]
        public ActionResult Delete(long id)
        {
            var result = _touristEquipmentService.Delete(id);
            return CreateResponse(result);
        }
    }
}