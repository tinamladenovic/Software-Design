using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories;

public class CheckpointDatabaseRepository : ICheckpointRepository
{
    private readonly ToursContext _dbContext;
    private readonly DbSet<Checkpoint> _dbSet;
    public CheckpointDatabaseRepository(ToursContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<Checkpoint>();
    }

    public async Task<IEnumerable<Checkpoint>> GetAll()
    {
        var checkpoints = await _dbContext.Checkpoints.ToListAsync();
        return checkpoints;
    }


    public Checkpoint Create(Checkpoint checkpoint)
    {
        Console.WriteLine(checkpoint.Id);
        _dbSet.Add(checkpoint);
        _dbContext.SaveChanges();
        return checkpoint;
    }

    public Checkpoint Get(long id)
    {
        var entity = _dbSet.Find(id);
        if (entity == null) throw new KeyNotFoundException("Not found: " + id);
        return entity;
    }

    public void Delete(int id)
    {
        var entity = Get(id);
        _dbSet.Remove(entity);
        _dbContext.SaveChanges();
    }

    public PagedResult<Checkpoint> GetAllByTourId(int page, int pageSize, long tourId)
    {
        var query = _dbContext.Checkpoints.Where(c => c.TourId == tourId);
        var task = query.GetPaged<Checkpoint>(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public Checkpoint Update(Checkpoint checkpoint)
    {
        var entity = _dbContext.Checkpoints.AsNoTracking().FirstOrDefault(e => e.Id == checkpoint.Id);
        _dbContext.Update(checkpoint);
        _dbContext.SaveChanges();
        return checkpoint;
    }

    public PagedResult<Checkpoint> GetPagedPublic(int page, int pageSize)
    {
        var query = _dbContext.Checkpoints.Where(c => c.Request != null);
        query = query.Where(c => c.Request.Status == CheckpointRequestStatus.Accepted);
        var task = query.GetPaged<Checkpoint>(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public Checkpoint AcceptCheckpoint(long id)
    {
        var entity = Get(id);
        if (entity == null) throw new KeyNotFoundException("Not found: " + id);
        if (entity.Request == null) throw new InvalidOperationException("Checkpoint has no request.");
        if (entity.Request.Status != CheckpointRequestStatus.Pending) throw new InvalidOperationException("Checkpoint is not pending.");
        entity.Accept();
        _dbContext.SaveChanges();
        return entity;
    }

    public Checkpoint RejectCheckpoint(long id, string comment)
    {
        var entity = Get(id);
        if (entity == null) throw new KeyNotFoundException("Not found: " + id);
        if (entity.Request == null) throw new InvalidOperationException("Checkpoint has no request.");
        if (entity.Request.Status != CheckpointRequestStatus.Pending) throw new InvalidOperationException("Checkpoint is not pending.");
        entity.Reject(comment);
        _dbContext.SaveChanges();
        return entity;
    }
    
    public PagedResult<Checkpoint> GetAllAdministratorCheckpoints(int page, int pageSize)
    {
        var query = _dbContext.Checkpoints.Where(c => c.Request != null);
        var task = query.GetPaged<Checkpoint>(page, pageSize);
        task.Wait();
        return task.Result;
    }
    
    public bool CheckPointsAreValidForPublish(int page, int pageSize, int tourId)
    {
        var checkpoints = GetAllByTourId(page, pageSize, tourId);
        return checkpoints.TotalCount >= 2;
    }
    
}
