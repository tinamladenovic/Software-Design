using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class TouristNotesRepository : ITouristNotesRepository
    {
        protected readonly StakeholdersContext DbContext;
        private readonly DbSet<TouristNote> _dbSet;

        public TouristNotesRepository(StakeholdersContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<TouristNote>();
        }

        public PagedResult<TouristNote> GetPagedForTourist(int touristId, int page, int pageSize)
        {
            var task = _dbSet.Where<TouristNote>(note => note.UserId == touristId).GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }
    }
}
