using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Encounters.API.Dtos;

namespace Explorer.Encounters.API.Public
{
    public interface IEncounterService
    {
        Result<EncounterDto> Get(long id);
        Result<PagedResult<EncounterDto>> GetAllActive();
        Result<EncounterDto> GetForCheckpoint(long checkpointId);
        Result<PagedResult<EncounterDto>> GetAllCheckpointRelated();
        Result<PagedResult<EncounterDto>> GetAllCheckpointUnrelated();
        Result<PagedResult<EncounterDto>> GetPaged(int page, int pageSize);
        Result<EncounterDto> Create(EncounterDto encounter);
        Result<EncounterDto> Update(EncounterDto encounter);
        Result<EncounterStatisticsDto> GetStatistics(long encounterId);
        Result Delete(int id);
    }
}
