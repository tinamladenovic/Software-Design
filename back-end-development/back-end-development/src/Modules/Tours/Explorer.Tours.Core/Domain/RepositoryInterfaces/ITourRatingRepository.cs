using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface  ITourRatingRepository : ICrudRepository<TourRating>
    {
        Result<List<TourRating>> GetAll();
        Result<List<TourRating>> GetAllByToursId(long tourId);
        int GetRatingsCountForPastWeek(long tourId);
        double GetAverageRatingForPastWeek(long tourId);
        List<TourRating> GetAllByToursIdList(long tourId);
    }
}
