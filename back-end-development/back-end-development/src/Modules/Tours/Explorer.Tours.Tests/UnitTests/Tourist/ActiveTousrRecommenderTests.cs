using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Encounters.Core.Domain;
using Explorer.Payments.API.Internal;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Internal;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.Core.UseCases.Tourist;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace Explorer.Tours.Tests.UnitTests.Tourist
{
    public class ActiveTousrRecommenderTests
    {
        [Fact]
        public void Returns_ranked_tours()
        {
            // Arrange
            var tourRecommender = new ActiveToursRecommender(getTourRatingService(), getInternalPersonService(),
                getInternalOrderService(), getCheckpointService(false), getMapper());

            // Act
            var result = tourRecommender.GetRecommendedTours(1);

            // Assert
            result.ShouldNotBe(null);
            result.IsSuccess.ShouldBe(true);
            result.Value.Results.Count.ShouldBe(5);
            result.Value.Results[0].Id.ShouldBe(2);
            result.Value.Results[1].Id.ShouldBe(5);
            result.Value.Results[2].Id.ShouldBe(3);
            result.Value.Results[3].Id.ShouldBe(1);
            result.Value.Results[4].Id.ShouldBe(4);
        }

        [Fact]
        public void Returns_no_tours_in_tourist_range()
        {
            // Arrange
            var tourRecommender = new ActiveToursRecommender(getTourRatingService(), getInternalPersonService(),
                getInternalOrderService(), getCheckpointService(true), getMapper());

            // Act
            var result = tourRecommender.GetRecommendedTours(1);

            // Assert
            result.ShouldNotBe(null);
            result.IsSuccess.ShouldBe(true);
            result.Value.Results.Count.ShouldBe(0);
        }

        private IMapper getMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Coordinate, StakeholdersCoordinateDto>().ReverseMap();
            });
            return config.CreateMapper();
        }

        private ICheckpointService getCheckpointService(bool shouldReturnEmpty)
        {
            var stubService = new Mock<ICheckpointService>();
            if (shouldReturnEmpty)
            {
                stubService.Setup(s => s.GetToursInRange(It.IsAny<TourSearchDto>())).Returns(getEmptyTours());
            }
            else
            {
                stubService.Setup( s => s.GetToursInRange(It.IsAny<TourSearchDto>())).Returns(getTours());
            }

            return stubService.Object;
        }   

        private ITourRatingService getTourRatingService()
        {
            var stubService = new Mock<ITourRatingService>();
            stubService.Setup(s => s.GetAverageRatingForPastWeek(It.IsAny<long>())).Returns((long tourId) => getAverageRatingForPastWeek(tourId));
            stubService.Setup(s => s.GetRatingsCountForPastWeek(It.IsAny<long>())).Returns((long tourId) => getRatingsCountForPastWeek(tourId));

            return stubService.Object;
        }

        private IInternalPersonService getInternalPersonService()
        {
            var stubService = new Mock<IInternalPersonService>();
            stubService.Setup(s => s.GetPersonLocation(It.IsAny<long>())).Returns(new StakeholdersCoordinateDto(45.2396M, 19.8227M));

            return stubService.Object;
        }

        private IInternalOrderService getInternalOrderService()
        {
            var stubService = new Mock<IInternalOrderService>();
            stubService.Setup(s => s.GetOrderCount(It.IsAny<long>())).Returns((long tourId) => getOrderCount(tourId));

            return stubService.Object;
        }

        private Result<int> getOrderCount(long tourId)
        {
            switch (tourId)
            {
                case 1:
                    return Result.Ok(7);
                case 2:
                    return Result.Ok(30);
                case 3:
                    return Result.Ok(15);
                case 4:
                    return Result.Ok(5);  
                case 5:
                    return Result.Ok(25);
                default:
                    return Result.Ok(0);
            }
        }

        private Result<int> getRatingsCountForPastWeek(long tourId)
        {
            switch (tourId)
            {
                case 1:
                    return Result.Ok(17);  
                case 2:
                    return Result.Ok(25); 
                case 3:
                    return Result.Ok(15);
                case 4:
                    return Result.Ok(2); 
                case 5:
                    return Result.Ok(10);
                default:
                    return Result.Ok(0);
            }
        }

        private Result<double> getAverageRatingForPastWeek(long tourId)
        {
            switch (tourId)
            {
                case 1:
                    return Result.Ok(3.8); 
                case 2:
                    return Result.Ok(4.8); 
                case 3:
                    return Result.Ok(4.55);
                case 4:
                    return Result.Ok(3.5); 
                case 5:
                    return Result.Ok(4.7);
                default:
                    return Result.Ok(0.0);
            }
        }

        private Task<Result<List<TourDto>>> getTours()
        {
            var tours = new List<TourDto>
            {
                new ()
                {
                    Id = 1,
                    Name = "Tour 1",
                },
                new ()
                {
                    Id = 2,
                    Name = "Tour 2",
                },
                new ()
                {
                    Id = 3,
                    Name = "Tour 3",
                },
                new ()
                {
                    Id = 4,
                    Name = "Tour 4",
                },
                new ()
                {
                    Id = 5,
                    Name = "Tour 5",
                },
            };

            var result = Result.Ok(tours);
            return Task.FromResult(result);
        }

        private Task<Result<List<TourDto>>> getEmptyTours()
        {
            var tours = new List<TourDto>();

            var result = Result.Ok(tours);
            return Task.FromResult(result);
        }
    }
}
