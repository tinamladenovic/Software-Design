using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.UseCases.Tourist.Execution;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Administrator.Administration
{
    [Route("api/administration/encounter")]

    public class EncounterController : BaseApiController
    {
        private readonly IEncounterService _encountersService;

        public EncounterController(IEncounterService encountersService)
        {
            _encountersService = encountersService;
        }

        [HttpGet]
        public ActionResult<PagedResult<EncounterDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _encountersService.GetAllCheckpointUnrelated();
            return CreateResponse(result);
        }

        [HttpGet("statistics/{encounterId:long}")]
        public ActionResult<EncounterStatisticsDto> GetStatistics(long encounterId)
        {
            var result = _encountersService.GetStatistics(encounterId);
            return CreateResponse(result);
        }

        [HttpGet("checkpoint")]
        public ActionResult<EncounterDto> GetAllForCheckpoint()
        {
            var result = _encountersService.GetAllCheckpointRelated();
            return CreateResponse(result);
        }

        [HttpGet("checkpoint/{checkpointId:long}")]
        public ActionResult<EncounterDto> GetForCheckpoint(long checkpointId)
        {
            var result = _encountersService.GetForCheckpoint(checkpointId);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<EncounterDto> Create([FromBody] EncounterDto encounter)
        {
            var result = _encountersService.Create(encounter);
            return CreateResponse(result);
        }

        [HttpPut]
        public ActionResult<EncounterDto> Update([FromBody] EncounterDto encounter)
        {
            var result = _encountersService.Update(encounter);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _encountersService.Delete(id);
            return CreateResponse(result);
        }
    }
}
