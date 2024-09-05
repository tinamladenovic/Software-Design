using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Explorer.Tours.API.Public.Author;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/equipment")]
    public class AuthorEquipmentController : BaseApiController
    {
        private readonly IAuthorEquipmnetService _authorEquipmentService;

        public AuthorEquipmentController(IAuthorEquipmnetService equipmentService)
        {
            _authorEquipmentService = equipmentService;
        }

        [HttpGet]
        public ActionResult<PagedResult<EquipmentDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _authorEquipmentService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<EquipmentDto> Create([FromBody] EquipmentDto equipment)
        {
            var result = _authorEquipmentService.Create(equipment);
            return CreateResponse(result);
        }

       
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _authorEquipmentService.Delete(id);
            return CreateResponse(result);
        }

       // [HttpGet("tourequipment")]
        /*public ActionResult<PagedResult<EquipmentDto>> GetEquipmentByTourId([FromQuery] int tourId, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _authorEquipmentService.GetEquipmentByTourId(tourId, page, pageSize);
            return CreateResponse(result);
        }*/
    }
}
