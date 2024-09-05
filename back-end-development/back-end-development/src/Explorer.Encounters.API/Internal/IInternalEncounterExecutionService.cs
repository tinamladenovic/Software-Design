﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Internal
{
    public interface IInternalEncounterExecutionService
    {
        Result<EncounterExecutionDto> Activate(long encounterId, long touristId, EncounterCoordinateDto currentPosition);
        Result<EncounterExecutionDto> Abandon(long executionId, long touristId);
        Result<EncounterExecutionDto> CheckIfCompleted(long executionId, long touristId, EncounterCoordinateDto currentPosition);
        Result<List<EncounterExecutionDto>> GetByEncounterId(long encounterId);
    }
}
