using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Internal
{
    public interface IInternalEncounterService
    {
        Result<EncounterDto> Create(EncounterDto encounter);
        Result<EncounterDto> GetForCheckpoint(long checkpointId);
        Result<EncounterDto> Update(EncounterDto encounter);
    }
}
