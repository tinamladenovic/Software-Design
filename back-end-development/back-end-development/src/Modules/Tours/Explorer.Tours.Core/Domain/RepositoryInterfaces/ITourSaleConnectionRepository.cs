using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ITourSaleConnectionRepository
    {
        List<TourSaleConnection> GetAllForTour(long id);
        TourSaleConnection Create(TourSaleConnection entity);
        List<TourSaleConnection> GetAllForSale(long id);
        void Delete(long id);
        TourSaleConnection Get(long id);
    }
}
