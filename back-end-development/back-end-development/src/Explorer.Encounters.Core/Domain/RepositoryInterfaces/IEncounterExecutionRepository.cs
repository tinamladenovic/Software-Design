using Explorer.BuildingBlocks.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Explorer.Encounters.Core.Domain.RepositoryInterfaces
{
    public interface IEncounterExecutionRepository : ICrudRepository<EncounterExecution>
    {
        PagedResult<EncounterExecution> GetAllForTouristId(long id);
        PagedResult<EncounterExecution> GetAllForEncounterId(long id);
        PagedResult<EncounterExecution> GetAllActiveForEncounterId(long id);
        PagedResult<EncounterExecution> GetByUserId(long userId);
    }
}
