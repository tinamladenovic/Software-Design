using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.TourExecutions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourExecutionStatsRepository : ITourExecutionStatsRepository
    {
        private readonly ToursContext _dbContext;
        private readonly DbSet<TourExecution> _dbSet;

        public TourExecutionStatsRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TourExecution>();
        }
        public int GetCompletedTourExecutionCount()
        {
            return _dbSet.Count(x => x.Status == TourExecutionStatus.Completed);
        }

        public double GetTotalCoveredDistance()
        {
            return _dbSet.Sum(x => x.CoveredDistance);
        }

        public int GetTouristCompletedTourExecutionCount(long touristId)
        {
            return _dbSet.Count(x => x.TouristId == touristId && x.Status == TourExecutionStatus.Completed);
        }


        public double GetTouristTotalCoveredDistance(long touristId)
        {
            return _dbSet.Where(x => x.TouristId == touristId).Sum(x => x.CoveredDistance);
        }

        public List<long> GetTouristIdsForCompletedExecutionsThisMonth()
        {
            var completedExecutionsThisMonth = _dbSet
                .Where(execution => execution.Status == TourExecutionStatus.Completed && execution.LastActivity >= getStartOfMonth())
                .Select(execution => execution.TouristId)
                .Distinct()
                .ToList();

            return completedExecutionsThisMonth;
        }

        public List<long> GetTouristIdsForCompletedExecutionsThisWeek()
        {
            var completedExecutionsThisMonth = _dbSet
                .Where(execution => execution.Status == TourExecutionStatus.Completed && execution.LastActivity >= getStartOfWeek())
                .Select(execution => execution.TouristId)
                .Distinct()
                .ToList();

            return completedExecutionsThisMonth;
        }

        public int GetTouristCompletedTourExecutionCountThisMonth(long touristId)
        {
            return _dbSet.Count(x => x.TouristId == touristId && 
                                     x.Status == TourExecutionStatus.Completed && 
                                     x.LastActivity >= getStartOfMonth());
        }

        public double GetTouristTotalCoveredDistanceThisMonth(long touristId)
        {
            return _dbSet.Where(x => x.TouristId == touristId && x.LastActivity >= getStartOfMonth())
                         .Sum(x => x.CoveredDistance);
        }

        public int GetTouristCompletedTourExecutionCountThisWeek(long touristId)
        {
            return _dbSet.Count(x => x.TouristId == touristId &&
                                     x.Status == TourExecutionStatus.Completed &&
                                     x.LastActivity >= getStartOfWeek());
        }

        public double GetTouristTotalCoveredDistanceThisWeek(long touristId)
        {
            return _dbSet.Where(x => x.TouristId == touristId && x.LastActivity >= getStartOfWeek())
                         .Sum(x => x.CoveredDistance);
        }

        private DateTime getStartOfMonth()
        {
            return new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        }

        private DateTime getStartOfWeek()
        {
            DateTime currentDate = DateTime.UtcNow;
            int daysToSubtract = (int)currentDate.DayOfWeek - (int)DayOfWeek.Monday;
            if (daysToSubtract < 0) daysToSubtract += 7; // Adjust for Sunday

            return currentDate.Date.AddDays(-daysToSubtract).AddHours(0).AddMinutes(0).AddSeconds(0);
        }

    }
}
