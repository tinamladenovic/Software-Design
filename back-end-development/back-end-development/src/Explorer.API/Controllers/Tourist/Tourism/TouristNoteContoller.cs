using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Tourism
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourism/touristNote")]

    public class TouristNoteContoller : BaseApiController
    {
        private readonly ITouristNoteService _touristNoteService;

        public TouristNoteContoller(ITouristNoteService touristNoteService)
        {
            _touristNoteService = touristNoteService;
        }

        [HttpGet]
        public ActionResult<PagedResult<TouristNoteDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _touristNoteService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<TouristNoteDto> Create([FromBody] TouristNoteDto touristNote)
        {
            var result = _touristNoteService.Create(touristNote);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<TouristNoteDto> Update([FromBody] TouristNoteDto touristNote)
        {
            var result = _touristNoteService.Update(touristNote);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _touristNoteService.Delete(id);
            return CreateResponse(result);
        }

        [HttpGet("/user/{id:int}")]
        public ActionResult<PagedResult<TouristNoteDto>> GetAllForTourist(int id, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _touristNoteService.GetPagedForTourist(id, page, pageSize);
            return CreateResponse(result);
        }
    }
}
