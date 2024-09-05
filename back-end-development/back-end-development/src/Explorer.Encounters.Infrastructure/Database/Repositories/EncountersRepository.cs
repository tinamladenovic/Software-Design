using Explorer.BuildingBlocks.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.Core.Domain;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.Core.Domain.NewFolder;
using FluentResults;

namespace Explorer.Encounters.Infrastructure.Database.Repositories
{
    public class EncountersRepository : CrudDatabaseRepository<Encounter, EncountersContext>, IEncountersRepository
    {
        private readonly DbSet<Encounter> _dbSet;

        public EncountersRepository(EncountersContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Encounter>();
        }

        public PagedResult<Encounter> GetAllActive()
        {
            var encounters = _dbSet.Where(e => e.Status == EncounterStatus.Active && !e.CheckpointId.HasValue);
            return new PagedResult<Encounter>(encounters.ToList(), encounters.Count());
        }

        public PagedResult<Encounter> GetAll()
        {
            return GetPaged(0, 0);
        }

        public PagedResult<Encounter> GetAllCheckpointUnrelated()
        {
            var encounters = _dbSet.Where(e => !e.CheckpointId.HasValue);
            return new PagedResult<Encounter>(encounters.ToList(), encounters.Count());
        }

        public PagedResult<Encounter> GetAllCheckpointRelated()
        {
            var encounters = _dbSet.Where(e => e.CheckpointId.HasValue);
            return new PagedResult<Encounter>(encounters.ToList(), encounters.Count());
        }

        public Encounter GetForCheckpoint(long id)
        {
            var entity = _dbSet.FirstOrDefault(e => e.CheckpointId == id);
            return entity;
        }

        public Encounter GetById(long id)
        {
            var entity = _dbSet.FirstOrDefault(e => e.Id == id);
            return entity;
        }

    }
}
