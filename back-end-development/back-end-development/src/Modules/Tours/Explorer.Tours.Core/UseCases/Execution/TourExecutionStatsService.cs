using Explorer.Tours.API.Public.TourExecution;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Internal;
using Explorer.Tours.API.Dtos.Leaderboards;

namespace Explorer.Tours.Core.UseCases.Execution
{
    public class TourExecutionStatsService : ITourExecutionStatsService
    {
        private readonly ITourExecutionStatsRepository _tourExecutionStatsRepository;
        private readonly IInternalPersonService _personService;
        public TourExecutionStatsService(ITourExecutionStatsRepository tourExecutionStatsRepository, IInternalPersonService personService)
        {
            _tourExecutionStatsRepository = tourExecutionStatsRepository;
            _personService = personService;
        }
        public Result<double> GetTotalCoveredDistance()
        {
            return _tourExecutionStatsRepository.GetTotalCoveredDistance();
        }

        public Result<double> GetTouristTotalCoveredDistance(long touristId)
        {
            return _tourExecutionStatsRepository.GetTouristTotalCoveredDistance(touristId);
        }

        public Result<int> GetCompletedTourExecutionCount()
        {
            return _tourExecutionStatsRepository.GetCompletedTourExecutionCount();
        }

        public Result<int> GetTouristCompletedTourExecutionCount(long touristId)
        {
            return _tourExecutionStatsRepository.GetTouristCompletedTourExecutionCount(touristId);
        }

        public Result<PagedResult<TouristCompletedToursDto>> GetTouristsRankedByCompletedToursThisMonth(int page, int pageSize)
        {
            var touristIds = _tourExecutionStatsRepository.GetTouristIdsForCompletedExecutionsThisMonth();
            var touristStats = getTouristCompletedTourStats(touristIds, weekly: false);

            touristStats = touristStats.OrderByDescending(t => t.CompletedTours).ToList();
            if (touristStats.Count > 0)
                rankByCompletedTours(touristStats);
            return new PagedResult<TouristCompletedToursDto>(touristStats, touristStats.Count);
        }

        public Result<PagedResult<TouristCompletedToursDto>> GetTouristsRankedByCompletedToursThisWeek(int page, int pageSize)
        {
            var touristIds = _tourExecutionStatsRepository.GetTouristIdsForCompletedExecutionsThisWeek();
            var touristStats = getTouristCompletedTourStats(touristIds, weekly: true);

            touristStats = touristStats.OrderByDescending(t => t.CompletedTours).ToList();
            if (touristStats.Count > 0)
                rankByCompletedTours(touristStats);
            return new PagedResult<TouristCompletedToursDto>(touristStats, touristStats.Count);
        }

        private List<TouristCompletedToursDto> getTouristCompletedTourStats(List<long> touristIds, bool weekly = false)
        {
            var touristStats = new List<TouristCompletedToursDto>();
            foreach (var touristId in touristIds)
            {
                var completedTours = weekly ? _tourExecutionStatsRepository.GetTouristCompletedTourExecutionCountThisWeek(touristId) :
                                              _tourExecutionStatsRepository.GetTouristCompletedTourExecutionCountThisMonth(touristId);
                var name = _personService.GetName(touristId);
                var surname = _personService.GetSurname(touristId);
                touristStats.Add(new TouristCompletedToursDto(touristId, 0, name.Value, surname.Value, completedTours));
            }

            return touristStats;
        }

        private void rankByCompletedTours(List<TouristCompletedToursDto> rankedTourists)
        {
            rankedTourists.First().Rank = 1;
            var previousTourist = rankedTourists.First();
            for (int i = 0; i < rankedTourists.Count; i++)
            {
                if (rankedTourists[i].CompletedTours == previousTourist.CompletedTours)
                {
                    rankedTourists[i].Rank = previousTourist.Rank;
                }
                else
                {
                    rankedTourists[i].Rank = i + 1;
                }
                previousTourist = rankedTourists[i];
            }
        }   

        public Result<PagedResult<TouristCoveredDistanceDto>> GetTouristsRankedByCoveredDistanceThisMonth(int page, int pageSize)
        {
            var touristIds = _tourExecutionStatsRepository.GetTouristIdsForCompletedExecutionsThisMonth();
            var touristStats = getTouristCoveredDistanceStats(touristIds, weekly: false);

            touristStats = touristStats.OrderByDescending(t => t.CoveredDistance).ToList();
            if (touristStats.Count > 0)
                rankByCoveredDistance(touristStats);
            return new PagedResult<TouristCoveredDistanceDto>(touristStats, touristStats.Count);
        }

        public Result<PagedResult<TouristCoveredDistanceDto>> GetTouristsRankedByCoveredDistanceThisWeek(int page, int pageSize)
        {
            var touristIds = _tourExecutionStatsRepository.GetTouristIdsForCompletedExecutionsThisWeek();
            var touristStats = getTouristCoveredDistanceStats(touristIds, weekly: true);

            touristStats = touristStats.OrderByDescending(t => t.CoveredDistance).ToList();
            if (touristStats.Count > 0)
                rankByCoveredDistance(touristStats);
            return new PagedResult<TouristCoveredDistanceDto>(touristStats, touristStats.Count);
        }

        private List<TouristCoveredDistanceDto> getTouristCoveredDistanceStats(List<long> touristIds, bool weekly = false)
        {
            var touristStats = new List<TouristCoveredDistanceDto>();
            foreach (var touristId in touristIds)
            {
                var coveredDistance = weekly ? _tourExecutionStatsRepository.GetTouristTotalCoveredDistanceThisWeek(touristId) : 
                                               _tourExecutionStatsRepository.GetTouristTotalCoveredDistanceThisMonth(touristId);
                var name = _personService.GetName(touristId);
                var surname = _personService.GetSurname(touristId);
                touristStats.Add(new TouristCoveredDistanceDto(touristId, 0, name.Value, surname.Value, coveredDistance));
            }

            return touristStats;
        }

        private void rankByCoveredDistance(List<TouristCoveredDistanceDto> rankedTourists)
        {
            rankedTourists.First().Rank = 1;
            var previousTourist = rankedTourists.First();
            for (int i = 0; i < rankedTourists.Count; i++)
            {
                if (rankedTourists[i].CoveredDistance == previousTourist.CoveredDistance)
                {
                    rankedTourists[i].Rank = previousTourist.Rank;
                }
                else
                {
                    rankedTourists[i].Rank = i + 1;
                }
                previousTourist = rankedTourists[i];
            }
        }
    }
}
