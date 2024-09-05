using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ITourExecutionStatsRepository
    {
        int GetCompletedTourExecutionCount();
        double GetTotalCoveredDistance();
        int GetTouristCompletedTourExecutionCount(long touristId);
        double GetTouristTotalCoveredDistance(long touristId);
        List<long> GetTouristIdsForCompletedExecutionsThisMonth();
        List<long> GetTouristIdsForCompletedExecutionsThisWeek();
        int GetTouristCompletedTourExecutionCountThisMonth(long touristId);
        double GetTouristTotalCoveredDistanceThisMonth(long touristId);
        int GetTouristCompletedTourExecutionCountThisWeek(long touristId);
        double GetTouristTotalCoveredDistanceThisWeek(long touristId);
    }
}
