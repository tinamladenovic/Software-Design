using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Leaderboards;

namespace Explorer.Tours.API.Public.TourExecution
{
    public interface ITourExecutionStatsService
    {
        Result<int> GetCompletedTourExecutionCount();
        Result<double> GetTotalCoveredDistance();
        Result<int> GetTouristCompletedTourExecutionCount(long touristId);
        Result<double> GetTouristTotalCoveredDistance(long touristId);
        Result<PagedResult<TouristCompletedToursDto>> GetTouristsRankedByCompletedToursThisMonth(int page, int pageSize);
        Result<PagedResult<TouristCoveredDistanceDto>> GetTouristsRankedByCoveredDistanceThisMonth(int page, int pageSize);
        Result<PagedResult<TouristCompletedToursDto>> GetTouristsRankedByCompletedToursThisWeek(int page, int pageSize);
        Result<PagedResult<TouristCoveredDistanceDto>> GetTouristsRankedByCoveredDistanceThisWeek(int page, int pageSize);
    }
}
