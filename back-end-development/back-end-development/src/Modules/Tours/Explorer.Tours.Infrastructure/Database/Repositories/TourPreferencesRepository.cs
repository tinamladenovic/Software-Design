using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourPreferencesRepository : ITourPreferencesRepository
    {
        private readonly ToursContext _context;
        private readonly DbSet<TourPreferences> _dbSet;

        public TourPreferencesRepository(ToursContext context)
        {
            _context = context;
            _dbSet = context.Set<TourPreferences>();
        }
        public Result<PagedResult<TourPreferences>> GetByTourId(long tourId, int page, int pageSize)
        {
            var count = _context.TourPreferences.Where(t => t.TouristId == tourId).Count();

            IQueryable<TourPreferences> query = _context.TourPreferences.Where(t => t.TouristId == tourId);

            List<TourPreferences> items;

            items = query.ToList();

            return new PagedResult<TourPreferences>(items, count);
        }

        public Result<TourPreferences> GetByTouristId(long touristId)
        {
            return _dbSet.FirstOrDefault(tp => tp.TouristId == touristId);
        }
    }
}
