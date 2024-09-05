using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Author;

public interface ICheckpointService
{
    Result<PagedResult<CheckpointDto>> GetPaged(int page, int pageSize);
    Result<CheckpointDto> Get(int id);
    Result<CheckpointDto> Create(CheckpointDto checkpoint);
    Result<CheckpointDto> Update(CheckpointDto checkpoint);
    Result Delete(int id);
    Result<PagedResult<CheckpointDto>> GetAllByTourId(int page, int pageSize, long tourId);
    bool CheckPointsAreValidForPublish(int page, int pageSize, int tourId);
    Task<Result<List<TourDto>>> GetToursInRange(TourSearchDto tourSearchDto);
    bool IsWithinCheckpoint(int checkpointId, CoordinateDto coordinate, double distanceInMeters);
    Result<PagedResult<CheckpointDto>> GetAllPublicCheckpoints(int page, int pageSize);
    Result<CheckpointDto> AcceptCheckpoint(long id);
    Result<CheckpointDto> RejectCheckpoint(long id, string comment);
    Result<PagedResult<CheckpointDto>> GetAllAdministratorCheckpoints(int page, int pageSize);
    bool HasCompletedEncounter(long checkpointId, long touristId, CoordinateDto coordinateDto);
}
