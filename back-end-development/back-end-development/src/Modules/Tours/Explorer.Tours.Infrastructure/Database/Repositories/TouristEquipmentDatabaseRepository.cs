using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
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
    public class TouristEquipmentDatabaseRepository : ITouristEquipmentRepository
    {
        private readonly ToursContext _dbContext;
        public TouristEquipmentDatabaseRepository(ToursContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public TouristEquipment Get(long id)
        {
            var entity = _dbContext.TouristEquipment.Find(id);
            if (entity == null) throw new KeyNotFoundException("Not found: " + id);
            return entity;
        }

        public PagedResult<TouristEquipment> GetPagedById(int page, int pageSize, long touristId)
        {
            var query = _dbContext.TouristEquipment.Where(t => t.TouristId == touristId);
            var task = query.GetPaged(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public PagedResult<TouristEquipment> GetPaged(int page, int pageSize)
        {
            var task = _dbContext.TouristEquipment.GetPaged(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public TouristEquipment Create(TouristEquipment entity)
        {
            _dbContext.TouristEquipment.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(long id)
        {
            var entity = Get(id);
            _dbContext.TouristEquipment.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
