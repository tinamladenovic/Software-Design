using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class CompositeTourRepository : ICompositeTourRepository
    {
        private readonly ToursContext _context;
        private readonly DbSet<CompositeTour> _dbSet;

        public CompositeTourRepository(ToursContext context)
        {
            _context = context;
            _dbSet = context.Set<CompositeTour>();
        }

        public Result<CompositeTour> GetById(long id)
        {
            IQueryable<CompositeTour> baseQuery = _context.CompositeTours
                .Include(ct => ct.Tours)
                    .ThenInclude(t => t.TourEquipment)
                .Include(ct => ct.Tours)
                    .ThenInclude(t => t.Checkpoints)
                .Where(t => t.Id == id);

            return baseQuery.SingleOrDefault();
        }

        public Result<PagedResult<CompositeTour>> GetByTouristId(long touristId, int page, int pageSize)
        {
            var count = _context.CompositeTours.Where(t => t.TouristId == touristId).Count();

            IQueryable<CompositeTour> query = _context.CompositeTours.Where(t => t.TouristId == touristId);

            List<CompositeTour> items;

            //if (pageSize != 0 && page != 0)
            //{
            //    query.Skip((page - 1) * pageSize).Take(pageSize);
            //    items = query.ToList();
            //}
            //else
            //{
            //    items = new List<Tour>();
            //}

            items = query
                .Include(ct => ct.Tours)  
                    .ThenInclude(t => t.TourEquipment) 
                .Include(ct => ct.Tours) 
                    .ThenInclude(t => t.Checkpoints)
                .ToList();




            return new PagedResult<CompositeTour>(items, count);
        }
    }
}
