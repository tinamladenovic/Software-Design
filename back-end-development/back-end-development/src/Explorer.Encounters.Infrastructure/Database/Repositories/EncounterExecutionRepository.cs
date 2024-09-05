using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using Explorer.Encounters.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;


namespace Explorer.Encounters.Infrastructure.Database.Repositories
{
    public class EncounterExecutionRepository : CrudDatabaseRepository<EncounterExecution, EncountersContext>, IEncounterExecutionRepository
    {
        private readonly DbSet<EncounterExecution> _dbSet;

        public EncounterExecutionRepository(EncountersContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<EncounterExecution>();
        }

        public PagedResult<EncounterExecution> GetAllForEncounterId(long id)
        {
            var encounterExecutions = _dbSet.Where(e => e.EncounterId == id);
            return new PagedResult<EncounterExecution>(encounterExecutions.ToList(), encounterExecutions.Count());
        }

        public PagedResult<EncounterExecution> GetAllActiveForEncounterId(long id)
        {
            var encounterExecutions = _dbSet.Where(e => e.EncounterId == id && e.Status == EncounterExecutionStatus.Active);
            return new PagedResult<EncounterExecution>(encounterExecutions.ToList(), encounterExecutions.Count());
        }

        public PagedResult<EncounterExecution> GetAllForTouristId(long id)
        {
            var encounterExecutions = _dbSet.Where(e => e.TouristId == id);
            return new PagedResult<EncounterExecution>(encounterExecutions.ToList(), encounterExecutions.Count());
        }

        public PagedResult<EncounterExecution> GetByUserId(long userId)
        {
            var entity = _dbSet.Where(e => e.TouristId == userId);
            return new PagedResult<EncounterExecution>(entity.ToList(), entity.Count());
        }
    }
}
