using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Internal;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.API.Public.TourExecution;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.TourExecutions;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.Domain.ValueObjects;
using Explorer.Tours.Core.Recommendation;
using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TourExecutionStatus = Explorer.Tours.Core.Domain.TourExecutions.TourExecutionStatus;

namespace Explorer.Tours.Core.UseCases.Execution;

public class TourExecutionService : BaseService<TourExecutionDto, TourExecution>, ITourExecutionService
{
    protected readonly ITourExecutionRepository _tourExecutionRepository;
    protected readonly ICheckpointService _checkpointService;
    protected readonly ITourService _tourService;
    protected readonly ICompositeTourService _compositeTourService;
    protected readonly IInternalFollowersService _internalFollowersService;
    public TourExecutionService(IMapper mapper, IInternalFollowersService internalFollowersService, ITourExecutionRepository tourExecutionRepository, ICheckpointService checkpointService, ITourService tourService, ICompositeTourService compositeTourService) : base(mapper)
    {
        _tourExecutionRepository = tourExecutionRepository;
        _checkpointService = checkpointService;
        _tourService = tourService;
        _compositeTourService = compositeTourService;
        _internalFollowersService = internalFollowersService;
    }

    public Result<TourExecutionDto> Create(int tourId, long touristId)
    {
        try
        {
            var checkpoints = _checkpointService.GetAllByTourId(0, 0, tourId).Value.Results;
            if (checkpoints.Count < 2) return Result.Fail(FailureCode.NotFound);

            if (!ValidateTouristOwnsTour(touristId, tourId))
                return Result.Fail(FailureCode.Forbidden);

            var checkpointIds = checkpoints.Select(c => c.Id).ToList();
            var result = _tourExecutionRepository.Create(new TourExecution(touristId, tourId,checkpointIds));
            return MapToDto(result);
        }
        catch (Exception ex)
        {
            return Result.Fail(FailureCode.Internal).WithError(ex.Message);
        }
    }

    public Result<TourExecutionDto> CreateForCompositeTour(int tourId, long touristId)
    {
        try
        {
            var checkpoints = _compositeTourService.GetCheckpoints(0, 0, tourId).Value.Results;
            if (checkpoints.Count < 2) return Result.Fail(FailureCode.NotFound);


            CompositeTourDto compositeTourDto = _compositeTourService.GetById(tourId).Value;
            bool isValid = true;
            foreach(TourDto tour in compositeTourDto.Tours)
            {
                if (!ValidateTouristOwnsTour(touristId, (int)tour.Id))
                {
                    isValid = false; 
                    break;
                }
            }
            if (!isValid)
                return Result.Fail(FailureCode.Forbidden);

            var checkpointIds = checkpoints.Select(c => c.Id).ToList();
            var result = _tourExecutionRepository.Create(new TourExecution(touristId, tourId, checkpointIds, true));
            return MapToDto(result);
        }
        catch (Exception ex)
        {
            return Result.Fail(FailureCode.Internal).WithError(ex.Message);
        }
    }

    private bool ValidateTouristOwnsTour(long touristId, int tourId)
    {
        var userTours = _tourService.GetTouristTours(0, 0, touristId).Value.Results;
        return userTours.Any(t => t.Id == tourId);
    }

    public Result Delete(int id)
    {
        try
        {
            _tourExecutionRepository.Delete(id);
            return Result.Ok();
        }
        catch (KeyNotFoundException e)
        {
            return Result.Fail(FailureCode.NotFound).WithError(e.Message);
        }
    }

    public Result<TourExecutionDto> Get(int id)
    {
        try
        {
            var result = _tourExecutionRepository.Get(id);
            return MapToDto(result);
        }
        catch (KeyNotFoundException e)
        {
            return Result.Fail(FailureCode.NotFound).WithError(e.Message);
        }
    }
    private Result<TourExecutionDto> Update(TourExecution tourExecution)
    {
        var result = _tourExecutionRepository.Update(tourExecution);
        return MapToDto(result);
    }

    public Result<TourExecutionDto> UpdateProgress(int id, int checkpointId, long touristId, TourExecutionUpdateDto currentPosition)
    {
        var tourExecution = _tourExecutionRepository.GetUntracked(id);
        if (tourExecution.TouristId != touristId)
            return Result.Fail(FailureCode.Forbidden);

        tourExecution.UpdateLastActivity();
        tourExecution.UpdateDistance(currentPosition.CoveredDistance);

        if (_checkpointService.IsWithinCheckpoint(checkpointId, currentPosition.Coordinate, 50) && _checkpointService.HasCompletedEncounter(checkpointId, touristId, currentPosition.Coordinate))
        {
            tourExecution.MarkCompleted(checkpointId);
        }
        return Update(tourExecution);
    }

    public Result<TourExecutionDto> Abandon(int tourExecutionId, long touristId)
    {
        var tourExecution = _tourExecutionRepository.GetUntracked(tourExecutionId);
        if (tourExecution.TouristId != touristId)
            return Result.Fail(FailureCode.Forbidden);
        tourExecution.Abandon();
        return Update(tourExecution);
    }

    public Result<List<long>> GetLast10FinishedTours(long touristId)
    {
        var finishedExecutions = _tourExecutionRepository.GetAll().Where(te => te.TouristId == touristId &&
                                                                               te.Status == TourExecutionStatus.Completed &&
                                                                               !te.IsComposite);

        var result = new List<long>();
        foreach (var execution in finishedExecutions)
        {
            result.Add(execution.TourId);
        }
        return result;
    }

    public Result<int> GetCountOfExecutionsForTour(int tourId)
    {
        return _tourExecutionRepository.GetCountOfExecutionsForTour(tourId);
    }

    public Result<int> GetNumberOfFinishesOfTour(int tourId)
    {
        return _tourExecutionRepository.GetNumberOfFinishesOfTour(tourId);
    }

    public Result<List<TourExecutionDto>> GetAllExecutionsForTour(int tourId)
    {
        var result = _tourExecutionRepository.GetAllExecutionsForTour(tourId);
        return MapToDto(result); 
    }
    
    public List<TourDto> GetRecomendedForTourAndUser(long tourId, long userId) 
    {
        List<long> followedIds = _internalFollowersService.GetUsersFollowedIds(userId);
        List<long> tourIds = new List<long>();
        List<long> toRemove = new List<long>();
        foreach (long fId in followedIds) 
        {
            TourExecution te = _tourExecutionRepository.GetByUserAndTourId(fId, tourId);
            if (te == null) 
            {
                toRemove.Add(fId);
                //followedIds.Remove(fId);
            }
        }
        foreach (long tr in toRemove) 
        {
            followedIds.Remove(tr);
        }
        foreach (long fId in followedIds)
        {
            List<TourExecution> tourExecutions = new List<TourExecution>();
            tourExecutions = _tourExecutionRepository.GetAllFinishedForTourist(fId);
            foreach (TourExecution te in tourExecutions) 
            {
                tourIds.Add(te.TourId);
            }
        }
        tourIds = tourIds.Distinct().ToList();
        bool help = true;
        foreach (long ti in tourIds) 
        {
            if (ti == tourId)
            {
                help = false;
            }
        }
        if (help == false) 
        {
        tourIds.Remove(tourId);
        }
        List<TourDto> tours = new List<TourDto>();
        foreach (long ti in tourIds) 
        {
            var tour = _tourService.GetById(ti);
            if (tour.IsSuccess) 
            {
                tours.Add(tour.Value);
            }
        }
        return tours;
    }
}
