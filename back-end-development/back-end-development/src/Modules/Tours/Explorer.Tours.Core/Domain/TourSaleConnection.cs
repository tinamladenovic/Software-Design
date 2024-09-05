using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class TourSaleConnection : Entity
    {
        public long TourId { get; private set; }
        public long SaleId { get; private set; }

        public TourSaleConnection()
        {

        }
        public TourSaleConnection(long tourId, long saleId)
        {
            TourId = tourId;
            SaleId = saleId;
        }
    }
}
