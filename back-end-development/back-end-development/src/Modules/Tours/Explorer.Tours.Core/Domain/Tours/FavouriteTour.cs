using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class FavouriteTour : Entity
    {
        public long TouristId { get; init; }
        public long TourId { get; init; }
        public Tour Tour { get; init; }

        public FavouriteTour(long touristId, long tourId)
        {
            TouristId = touristId;
            TourId = tourId;
        }
    }
}
