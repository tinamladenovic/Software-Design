using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class DestinationRepository : CrudDatabaseRepository<Destination, ToursContext>, IDestinationRepository
    {
        private readonly DbSet<Destination> _dbSet;
        public DestinationRepository(ToursContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Destination>();
        }

        public PagedResult<Destination> GetPagedForAuthor(long authorId, int page, int pageSize)
        {
            var task = _dbSet.Where(d => d.PersonId == authorId).GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }
    }
}
