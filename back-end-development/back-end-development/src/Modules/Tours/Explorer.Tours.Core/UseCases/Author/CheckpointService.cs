using System.Net;
using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Explorer.Encounters.API.Internal;
using Explorer.Encounters.API.Dtos;

namespace Explorer.Tours.Core.UseCases.Author;

public class CheckpointService : BaseService<CheckpointDto, Checkpoint>, ICheckpointService
{
    protected readonly ICheckpointRepository _checkpointRepository;
    protected readonly ITourService _tourService;
    protected readonly IInternalEncounterService _encounterService;
    protected readonly IInternalEncounterExecutionService _encounterExecutionService;
    protected readonly IMapper _mapper;
    

    public CheckpointService(IMapper mapper, ICheckpointRepository checkpointRepository, IInternalEncounterService encounterService, IInternalEncounterExecutionService encounterExecutionService, ITourService tourService) : base(mapper)
    {
        _checkpointRepository = checkpointRepository;
        _tourService = tourService;
        _encounterService = encounterService;
        _encounterExecutionService = encounterExecutionService;
        _mapper = mapper;
    }


    public async Task<Result<List<TourDto>>> GetToursInRange(TourSearchDto tourSearchDto)
    {
        try
        {
            var checkPointsInRange = FilterCheckPointsInRange(await _checkpointRepository.GetAll(), tourSearchDto);
            var Tours = BuildTourResults(checkPointsInRange);
            return _tourService.ReturnToursInRange(Tours.Value.Distinct().ToList());
        }
        catch (Exception ex)
        {
            return Result.Fail(FailureCode.NotFound).WithError(ex.Message);
        }
    }

    private List<Checkpoint> FilterCheckPointsInRange(IEnumerable<Checkpoint> checkpoints, TourSearchDto tourSearchDto)
    {
        var checkPointsInRange = new List<Checkpoint>();

        foreach (var item in checkpoints)
        {
            if (item.IsWithin(tourSearchDto.Latitude, tourSearchDto.Longitude, tourSearchDto.Range))
                checkPointsInRange.Add(item);
        }

        /*if (checkPointsInRange.Count == 0)
            throw new InvalidOperationException("No tour is expected");*/

        return checkPointsInRange;
    }

    private Result<List<TourDto>> BuildTourResults(List<Checkpoint> checkPointsInRange)
    {
        var ToursData = new List<TourDto>();

        foreach (var item in checkPointsInRange)
        {
            var tourResult = _tourService.GetById(item.TourId);
            if (tourResult.IsSuccess && tourResult.Value.Status == Status.PUBLISHED)
            {
                ToursData.Add(tourResult.Value);
            }
            if (tourResult.IsFailed)
            {
                throw new InvalidOperationException("No tour is expected");
            }
        }

        return Result.Ok(ToursData.DistinctBy(t => t.Id).ToList());
    }



    public bool IsWithinCheckpoint(int checkpointId, CoordinateDto coordinateDto, double distanceInMeters)
    {
        try
        {
            var result = _checkpointRepository.Get(checkpointId);
            Coordinate coordinate= new Coordinate(coordinateDto.Latitude, coordinateDto.Longitude);
            return result.Coordinates.IsCloseTo(coordinate, distanceInMeters);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool HasCompletedEncounter(long checkpointId, long touristId, CoordinateDto coordinateDto)
    {
        try
        {
            var encounterResult = _encounterService.GetForCheckpoint(checkpointId);

            //If there is no encounter for provided checkpoint - true
            if (encounterResult.IsFailed) return true;

            var encounter = encounterResult.Value;

            //If encounter is not required - true
            if (!(bool)encounter.IsRequired) return true;

            //If there is encounter, but user still not started it - false
            var encounterExecutions = _encounterExecutionService.GetByEncounterId(encounter.Id);
            if(encounterExecutions.IsFailed) return false;

            if (encounterExecutions.Value.Any(e => e.Status == EncounterExecutionStatusDto.Completed))
                return true;
          
            //It means that user still not completed it
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    


    public Result<CheckpointDto> Create(CheckpointDto checkpointDto)
    {
        try
        {
            Checkpoint checkpoint = MapToDomain(checkpointDto);
            var result = _checkpointRepository.Create(checkpoint);
            return MapToDto(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Result Delete(int id)
    {
        try
        {
            _checkpointRepository.Delete(id);
            return Result.Ok();
        }
        catch (KeyNotFoundException e)
        {
            return Result.Fail(FailureCode.NotFound).WithError(e.Message);
        }
    }

    public Result<CheckpointDto> Get(int id)
    {
        try
        {
            var result = _checkpointRepository.Get(id);
            return MapToDto(result);
        }
        catch (KeyNotFoundException e)
        {
            return Result.Fail(FailureCode.NotFound).WithError(e.Message);
        }
    }

    public Result<PagedResult<CheckpointDto>> GetAllByTourId(int page, int pageSize, long tourId)
    {
        var result = _checkpointRepository.GetAllByTourId(page, pageSize, tourId);
        return MapToDto(result);
    }

    public Result<PagedResult<CheckpointDto>> GetPaged(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Result<CheckpointDto> Update(CheckpointDto checkpoint)
    {
        var result = _checkpointRepository.Update(MapToDomain(checkpoint));
        return MapToDto(result);
    }

    public Result<PagedResult<CheckpointDto>> GetAllPublicCheckpoints(int page, int pageSize)
    {
        var result = _checkpointRepository.GetPagedPublic(page, pageSize);
        return MapToDto(result);
    }

    public Result<CheckpointDto> AcceptCheckpoint(long id)
    {
        var result = _checkpointRepository.AcceptCheckpoint(id);
        return MapToDto(result);
    }

    public Result<CheckpointDto> RejectCheckpoint(long id, string comment)
    {
        var result = _checkpointRepository.RejectCheckpoint(id, comment);
        return MapToDto(result);
    }
    
    public Result<PagedResult<CheckpointDto>> GetAllAdministratorCheckpoints(int page, int pageSize)
    {
        var result = _checkpointRepository.GetAllAdministratorCheckpoints(page, pageSize);
        return MapToDto(result);
    }
    
    public bool CheckPointsAreValidForPublish(int page, int pageSize, int tourId)
    {
        return _checkpointRepository.CheckPointsAreValidForPublish(page, pageSize, tourId);
    }
}
