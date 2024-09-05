using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;

namespace Explorer.Encounters.Core.Domain.NewFolder
{
    public interface IEncountersRepository : ICrudRepository<Encounter>
    {
        PagedResult<Encounter> GetAllActive();
        PagedResult<Encounter> GetAllCheckpointUnrelated();
        PagedResult<Encounter> GetAllCheckpointRelated();
        Encounter? GetForCheckpoint(long id);
        Encounter? GetById(long id);
    }
}
