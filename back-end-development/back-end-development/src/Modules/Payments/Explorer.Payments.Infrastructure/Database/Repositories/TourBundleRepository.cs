using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Core.Domain.TourPackages;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Payments.Infrastructure.Database.Repositories
{
    public class TourBundleRepository : ITourBundleRepository
    {
        private readonly PaymentsContext _dbContext;
        private readonly DbSet<TourBundle> _dbSet;

        public TourBundleRepository(PaymentsContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TourBundle>();
        }

        public Result<PagedResult<TourBundle>> GetAll(int page, int pageSize, long authorId)
        {

            var count = _dbSet.Where(tb => tb.AuthorId == authorId).Count();

            IQueryable<TourBundle> query = _dbSet.Where(t => t.AuthorId == authorId);

            List<TourBundle> bundles;

            bundles = query.ToList();

            return new PagedResult<TourBundle>(bundles, count);
        }
        public Result<PagedResult<TourBundle>> GetByTour(long tourId, int page, int pageSize)
        {
            var count = _dbSet.AsEnumerable().Where(bundle => bundle.Tours.Any(tour => tour.TourId == tourId)).Count();

            List<TourBundle> bundles = _dbSet.AsEnumerable().Where(bundle => bundle.Tours.Any(tour => tour.TourId == tourId)).ToList();

            return new PagedResult<TourBundle>(bundles, count);
        }

        public Result<PagedResult<TourBundle>> GetAll(int page, int pageSize)
        {

            var count = _dbSet.Count();

            IQueryable<TourBundle> query = _dbSet.Where(tb => tb.Status == Status.PUBLISHED);

            List<TourBundle> bundles;

            bundles = query.ToList();

            return new PagedResult<TourBundle>(bundles, count);
        }

        public TourBundle Get(long id)
        {
            var entity = _dbSet.AsNoTracking().FirstOrDefault(e => e.Id == id);

            if (entity == null)
            {
                throw new KeyNotFoundException("Not found: " + id);
            }

            return entity;
        }

        public TourBundle Create(TourBundle tourBundle)
        {
            try
            {
                _dbSet.Add(tourBundle);
                _dbContext.SaveChanges();
                return tourBundle;
            }
            catch (Exception e)
            {
                throw new DbUpdateException(e.Message);
            }
        }

        public TourBundle Update(TourBundle tourBundle)
        {
            try
            {
                _dbContext.Update(tourBundle);
                _dbContext.SaveChanges();
                return tourBundle;
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.Message);
            }
        }

        public void Delete(long id)
        {
            var entity = Get(id);
            _dbContext.RemoveRange(entity.Tours);
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
