using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.TourExecutions;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Explorer.Tours.Infrastructure.Database.Repositories;

public class TourExecutionRepository : ITourExecutionRepository
{
    private readonly ToursContext _dbContext;
    private readonly DbSet<TourExecution> _dbSet;

    public TourExecutionRepository(ToursContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TourExecution>();
    }

    public List<TourExecution> GetAll()
    {
        return _dbSet.ToList();
    }

    public TourExecution Create(TourExecution execution)
    {
        try
        {
            _dbSet.Add(execution);
            _dbContext.SaveChanges();
            return execution;
        }
        catch (Exception e)
        {
            throw new DbUpdateException(e.Message);
        }
    }

    public TourExecution Update(TourExecution execution)
    {
        try
        {
            _dbContext.Update(execution);
            _dbContext.SaveChanges();
            return execution;
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException(e.Message);
        }
    }

    public void Delete(long id)
    {
        var entity = Get(id);
        _dbContext.RemoveRange(entity.CheckpointStatuses);
        _dbSet.Remove(entity);
        _dbContext.SaveChanges();
    }

    public TourExecution Get(long id)
    {
        var entity = _dbSet.Find(id);
        if (entity == null) throw new KeyNotFoundException("Not found: " + id);
        return entity;
    }

    public TourExecution GetUntracked(long id)
    {
        var entity = _dbSet.AsNoTracking().FirstOrDefault(e => e.Id == id);

        if (entity == null)
        {
            throw new KeyNotFoundException("Not found: " + id);
        }

        return entity;
    }

    public Result<int> GetCountOfExecutionsForTour(int tourId)
    {
        int count = _dbContext.TourExecutions.Where(t => t.TourId == tourId && t.IsComposite == false).Count();
        return count;
    }

    public Result<int> GetNumberOfFinishesOfTour(int tourId)
    {
        int count = _dbContext.TourExecutions.Where(t => t.TourId == tourId && t.Status == TourExecutionStatus.Completed && t.IsComposite == false).Count();
        return count;
    }

    public Result<List<TourExecution>> GetAllExecutionsForTour(int tourId)
    {
        return _dbContext.TourExecutions.Where(t => t.TourId == tourId && t.IsComposite == false).ToList();
    }

    public TourExecution GetByUserAndTourId(long userId, long tourId) 
    {
        var entity = _dbSet.FirstOrDefault(e => e.TourId == tourId && e.TouristId == userId && e.Status== TourExecutionStatus.Completed);
        return entity == null ? null : entity;
    }

    public List<TourExecution> GetAllFinishedForTourist(long userId) 
    {
        List<TourExecution> list = new List<TourExecution>();
        list = _dbSet.Where(te => te.TouristId== userId && te.Status == TourExecutionStatus.Completed).ToList();
        return list;
    }

}
