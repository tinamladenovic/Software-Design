namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    using Explorer.BuildingBlocks.Core.UseCases;
    using Explorer.Stakeholders.Core.Domain;
    using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationRateRepository : IApplicationRateRepository
    {
        private readonly StakeholdersContext _dbContext;
        private readonly DbSet<ApplicationRate> _dbSet;
        public ApplicationRateRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<ApplicationRate>();
        }


        public PagedResult<ApplicationRate> GetApplicationRates(int page, int pageSize)
        {
            var count = _dbSet.Count();
            IQueryable<ApplicationRate> items = _dbSet.Include(e=>e.Person);

            if (pageSize != 0 && page != 0)
            {
                items = _dbSet.OrderByDescending(e => e.Id).Include(e => e.Person).Skip((page - 1) * pageSize).Take(pageSize);
            }
            
            return new PagedResult<ApplicationRate>(items.ToList(), count);
        }
    }
}
