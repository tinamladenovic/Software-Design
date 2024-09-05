using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces;

public interface ICheckpointRepository
{
    PagedResult<Checkpoint> GetAllByTourId(int page, int pageSize, long tourId);
    Checkpoint Create(Checkpoint checkpoint);
    Checkpoint Update(Checkpoint checkpoint);
    void Delete(int id);
    Checkpoint Get(long id);
    PagedResult<Checkpoint> GetPagedPublic(int page, int pageSize);
    Checkpoint AcceptCheckpoint(long id);
    Checkpoint RejectCheckpoint(long id, string comment);
    Task<IEnumerable<Checkpoint>> GetAll();
    PagedResult<Checkpoint> GetAllAdministratorCheckpoints(int page, int pageSize);
    bool CheckPointsAreValidForPublish(int page, int pageSize, int tourId);
}
