using Explorer.BuildingBlocks.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ITouristEquipmentRepository
    {
        public TouristEquipment Get(long id);

        public PagedResult<TouristEquipment> GetPagedById(int page, int pageSize, long touristId);

        public PagedResult<TouristEquipment> GetPaged(int page, int pageSize);

        public TouristEquipment Create(TouristEquipment entity);

        public void Delete(long id);
    }
}
