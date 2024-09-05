using Explorer.Encounters.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Public
{
    public interface IEncounterExecutionService
    {
        Result<EncounterExecutionDto> Activate(long encounterId, long touristId, EncounterCoordinateDto currentPosition);
        Result<EncounterExecutionDto> Abandon(long executionId, long touristId);
        Result<EncounterExecutionDto> CheckIfCompleted(long executionId, long touristId, EncounterCoordinateDto currentPosition);
        Result<EncounterExecutionDto> CompleteMiscEncounter(long executionId, long touristId);
        Result<EncounterStatisticsDto> GetStatisticsForUser(long userId);
    }
}
