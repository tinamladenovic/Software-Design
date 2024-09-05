using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.UseCases.Administration;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos.Execution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Execution
{
    [Authorize(Policy = "touristPolicy")]
    [Microsoft.AspNetCore.Mvc.Route("api/tourist/execution/encounter")]
    public class EncounterExecutionController : BaseApiController
    {
        private readonly IEncounterExecutionService _encounterExecutionService;
        private readonly IEncounterService _encounterService;

        public EncounterExecutionController(IEncounterExecutionService encounterExecutionService, IEncounterService encounterService)
        {
            _encounterExecutionService = encounterExecutionService;
            _encounterService = encounterService;
        }

        [HttpGet("statistics/user/{userId:long}")]
        public ActionResult<EncounterStatisticsDto> GetStatisticsForUser(long userId)
        {
            var result = _encounterExecutionService.GetStatisticsForUser(userId);
            return CreateResponse(result);
        }

        [HttpGet("allEncounters")]
        public ActionResult<EncounterDto> GetAllActive()
        {
            var result = _encounterService.GetAllActive();
            return CreateResponse(result);
        }

        [HttpPost("{encounterId:long}")]
        public ActionResult<EncounterExecutionDto> Activate(long encounterId, [FromBody] EncounterCoordinateDto currentPosition)
        {
            var result = _encounterExecutionService.Activate(encounterId, ClaimsPrincipalExtensions.PersonId(User), currentPosition);
            return CreateResponse(result);
        }

        [HttpPatch("{executionId:long}")]
        public ActionResult<EncounterExecutionDto> CheckIfCompleted(long executionId, [FromBody] EncounterCoordinateDto currentPosition)
        {
            var result = _encounterExecutionService.CheckIfCompleted(executionId, ClaimsPrincipalExtensions.PersonId(User), currentPosition);
            return CreateResponse(result);
        }

        [HttpPatch("completeMiscEncounter")]
        public ActionResult<EncounterExecutionDto> CompleteMiscEnctounter([FromBody] long executionId)
        {
            var result = _encounterExecutionService.CompleteMiscEncounter(executionId, ClaimsPrincipalExtensions.PersonId(User));
            return CreateResponse(result);
        }

        [HttpPatch("abandon")]
        public ActionResult<EncounterExecutionDto> Abandon([FromBody] long executionId)
        {
            var result = _encounterExecutionService.Abandon(executionId, ClaimsPrincipalExtensions.PersonId(User));
            return CreateResponse(result);
        }
    }
}
