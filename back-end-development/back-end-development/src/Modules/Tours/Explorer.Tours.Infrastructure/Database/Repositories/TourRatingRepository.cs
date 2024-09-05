using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourRatingRepository : CrudDatabaseRepository<TourRating, ToursContext>, ITourRatingRepository
    {
        private readonly ToursContext _context;
        private readonly DbSet<TourRating> _dbSet;

        public TourRatingRepository(ToursContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<TourRating>();
        }

        public Result<List<TourRating>> GetAll()
        {
            return _dbSet.ToList();
        }

        public Result<List<TourRating>> GetAllByToursId(long tourId)
        {
            return _dbSet.Where(t => t.TourId == tourId).ToList();
        }

        public List<TourRating> GetAllByToursIdList(long tourId)
        {
            return _dbSet.Where(t => t.TourId == tourId).ToList();
        }

        public int GetRatingsCountForPastWeek(long tourId)
        {
            return _dbSet.Count(t => t.TourId == tourId && t.Created >= DateTime.UtcNow.AddDays(-7));
        }

        public double GetAverageRatingForPastWeek(long tourId)
        {
            var query = _dbSet.Where(t => t.TourId == tourId && t.Created >= DateTime.UtcNow.AddDays(-7));

            if (query.Any())
            {
                return query.Average(t => t.Rating);
            }
            return 0;
        }
    }
}