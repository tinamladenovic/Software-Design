using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourSaleConnectionRepository : ITourSaleConnectionRepository
    {
        private readonly ToursContext _dbContext;

        public TourSaleConnectionRepository(ToursContext context)
        {
            _dbContext = context;
        }
        public List<TourSaleConnection> GetAllForTour(long id) 
        {
            return _dbContext.TourSaleConnections.Where(tourSaleConnection => tourSaleConnection.TourId == id).ToList();
        }
        public List<TourSaleConnection> GetAllForSale(long id)
        {
            return _dbContext.TourSaleConnections.Where(tourSaleConnection => tourSaleConnection.SaleId == id).ToList();
        }
        public TourSaleConnection Create(TourSaleConnection entity)
        {
            try
            {
                _dbContext.TourSaleConnections.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                throw new DbUpdateException(e.Message);
            }
        }
        public void Delete(long id)
        {
            var entity = Get(id);
            _dbContext.TourSaleConnections.Remove(entity);
            _dbContext.SaveChanges();
        }
        public TourSaleConnection Get(long id)
        {
            var entity = _dbContext.TourSaleConnections.Find(id);
            if (entity == null) throw new KeyNotFoundException("Not found: " + id);
            return entity;
        }
    }
}
