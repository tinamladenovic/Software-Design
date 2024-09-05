using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Public.Author;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.TourExecution;

public interface ITourExecutionService
{
    Result<TourExecutionDto> Get(int id);
    Result<TourExecutionDto> Create(int tourId, long touristId);
    Result<TourExecutionDto> CreateForCompositeTour(int tourId, long touristId);
    Result Delete(int id);
    Result<TourExecutionDto> UpdateProgress(int tourExecutionId, int checkpontId, long touristId, TourExecutionUpdateDto currentPosition);
    Result<TourExecutionDto> Abandon(int tourExecutionId, long touristId);
    Result<List<long>> GetLast10FinishedTours(long touristId);
    Result<int> GetCountOfExecutionsForTour(int tourId);
    Result<int> GetNumberOfFinishesOfTour(int tourId);
    Result<List<TourExecutionDto>> GetAllExecutionsForTour(int tourId);
    List<TourDto> GetRecomendedForTourAndUser(long tourId, long userId);
}
