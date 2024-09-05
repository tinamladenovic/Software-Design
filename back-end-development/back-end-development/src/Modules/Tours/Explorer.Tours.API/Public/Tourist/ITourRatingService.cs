using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Tourist
{
    public interface ITourRatingService
    {
        Result<PagedResult<TourRatingDto>> GetPaged(int page, int pageSize);
        Result<TourRatingDto> Create(TourRatingDto tourRating);
        Result<TourRatingDto> Update(TourRatingDto tourRating);
        Result Delete(int id);
        Result<int> GetRatingsCountForPastWeek(long tourId);
        Result<double> GetAverageRatingForPastWeek(long tourId);
        Result<List<long>> GetHighlyRatedTours();
        float GetAverageGradeForTour(long id);
        List<int> GetAllGradesForTour(long id);
    }
}
