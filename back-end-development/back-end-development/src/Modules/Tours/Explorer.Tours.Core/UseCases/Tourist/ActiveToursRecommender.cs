using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Internal;
using Explorer.Stakeholders.API.Internal;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Tourist;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.Core.Domain;

namespace Explorer.Tours.Core.UseCases.Tourist
{
    public class ActiveToursRecommender : IActiveToursRecommender
    {
        private readonly ICheckpointService _checkpointService;
        private readonly ITourRatingService _tourRatingService;
        private readonly IInternalPersonService _personService;
        private readonly IInternalOrderService _orderService;
        private readonly IMapper _mapper;

        public ActiveToursRecommender(ITourRatingService tourRatingService, IInternalPersonService personService, IInternalOrderService orderService,
            ICheckpointService checkpointService, IMapper mapper)
        {
            _tourRatingService = tourRatingService;
            _personService = personService;
            _orderService = orderService;
            _checkpointService = checkpointService;
            _mapper = mapper;
        }
        public Result<PagedResult<TourDto>> GetRecommendedTours(long touristId)
        {
            var tours = GetToursInTouristRange(GetTouristLocation(touristId));
            if (tours.Count == 0) return Result.Ok(new PagedResult<TourDto>(new List<TourDto>(), 0));

            var toursActivityStats = GetToursActivityStats(tours);
            CalculateAlgorithmScore(toursActivityStats);
            toursActivityStats = toursActivityStats.OrderByDescending(t => t.AlgorithmScore).ToList();

            var topTourIds = toursActivityStats.Take(10).Select(t => t.TourId).ToList();
            var topTours = tours
                .Where(t => topTourIds.Contains(t.Id))
                .OrderBy(t => topTourIds.IndexOf(t.Id))
                .ToList();

            return new PagedResult<TourDto>(topTours, topTours.Count);
        }

        private List<TourDto> GetToursInTouristRange(Coordinate touristLocation)
        {
            var searchRange = 40000;
            var tourSearchParams = new TourSearchDto(touristLocation.Latitude, touristLocation.Longitude, searchRange);
            var toursInRange = _checkpointService.GetToursInRange(tourSearchParams).Result;
            return toursInRange.Value;
        }

        private List<TourActivityStats> GetToursActivityStats(List<TourDto> tours)
        {
            List<TourActivityStats> toursActivityStats = new List<TourActivityStats>();
            foreach (TourDto tour in tours)
            {
                toursActivityStats.Add(new TourActivityStats(tour.Id, GetRatingsCountForPastWeek(tour.Id), GetPurchasesCount(tour.Id), GetAverageRatingForPastWeek(tour.Id)));
            }
            return toursActivityStats;
        }

        private void CalculateAlgorithmScore(List<TourActivityStats> toursActivityStats)
        {
            NormalizeStats(toursActivityStats);
            var averageRatingWeight = 0.5;
            var ordersCountWeight = 0.3;
            var ratingsCountWeight = 0.2;
            foreach (TourActivityStats tourActivityStats in toursActivityStats)
            {
                tourActivityStats.AlgorithmScore = tourActivityStats.AverageRating * averageRatingWeight +
                                                   tourActivityStats.OrdersCount * ordersCountWeight +
                                                   tourActivityStats.RatingsCount * ratingsCountWeight;
            }
        }

        private void NormalizeStats(List<TourActivityStats> toursActivityStats)
        {
            var maxRatingsCount = toursActivityStats.Max(t => t.RatingsCount);
            var maxAverageRating = toursActivityStats.Max(t => t.AverageRating);
            var maxOrderCount = toursActivityStats.Max(t => t.OrdersCount);

            foreach (var tour in toursActivityStats)
            {
                if (maxRatingsCount != 0)
                    tour.RatingsCount /= maxRatingsCount;
                if (maxAverageRating != 0)
                    tour.AverageRating /= maxAverageRating;
                if (maxOrderCount != 0)
                    tour.OrdersCount /= maxOrderCount;
            }
        }

        private int GetRatingsCountForPastWeek(long tourId)
        {
            return _tourRatingService.GetRatingsCountForPastWeek(tourId).Value;
        }

        private double GetAverageRatingForPastWeek(long tourId)
        {
            return _tourRatingService.GetAverageRatingForPastWeek(tourId).Value;
        }

        private int GetPurchasesCount(long tourId)
        {
            return _orderService.GetOrderCount(tourId).Value;
        }

        private Coordinate GetTouristLocation(long touristId)
        {
            return _mapper.Map<Coordinate>(_personService.GetPersonLocation(touristId).Value);
        }
    }
}
