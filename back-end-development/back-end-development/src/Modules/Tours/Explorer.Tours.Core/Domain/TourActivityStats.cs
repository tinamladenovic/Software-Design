using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class TourActivityStats
    {
        public long TourId { get; set; }
        public double RatingsCount { get; set; }
        public double OrdersCount { get; set; }
        public double AverageRating { get; set; }

        public double AlgorithmScore { get; set; }

        public TourActivityStats(long tourId, int ratingsCount, int ordersCount, double averageRating)
        {
            TourId = tourId;
            RatingsCount = ratingsCount;
            OrdersCount = ordersCount;
            AverageRating = averageRating;
        }
    }
}
