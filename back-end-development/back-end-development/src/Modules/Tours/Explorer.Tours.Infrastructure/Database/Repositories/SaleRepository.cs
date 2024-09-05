using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
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
    public class SaleRepository : ISaleRepository
    {
        private readonly ToursContext _dbContext;

        public SaleRepository(ToursContext context)
        {
            _dbContext = context;
        }
        public List<Sale> GetAllForAuthor(long id)
        {
            return _dbContext.Sales.Where(sale => sale.AuthorId == id).ToList();
        }
        public Sale GetById(long id)
        {
            Sale sale = _dbContext.Sales.Find(id);
            if (sale == null)
            {
                throw new KeyNotFoundException("Not found: " + id);
            }

            return sale;
        }
        public Sale Create(Sale entity)
        {
            try
            {
                _dbContext.Sales.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                throw new DbUpdateException(e.Message);
            }
        }
    }
}
