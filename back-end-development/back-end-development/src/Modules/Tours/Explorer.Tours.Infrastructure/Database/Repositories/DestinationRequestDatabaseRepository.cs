using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Tours.Infrastructure.Database.Repositories;

public class DestinationRequestDatabaseRepository : IDestinationRequestDatabaseRepository
{
    private readonly ToursContext _dbContext;

    public DestinationRequestDatabaseRepository(ToursContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Result<Destination> Accept(long id)
    {
        var request = _dbContext.Destinations.FirstOrDefault(d => d.Id == id);
        if (request == null) return Result.Fail("Not found: " + id);
        request.Accept();
        _dbContext.SaveChanges();
        return Result.Ok(request);
    }

    public Result<Destination> Reject(long id, string comment)
    {
        var request = _dbContext.Destinations.FirstOrDefault(d => d.Id == id);
        if (request == null) return Result.Fail("Not found: " + id);
        request.Reject(comment);
        _dbContext.SaveChanges();
        return Result.Ok(request);
    }

    public Result<PagedResult<Destination>> GetPublicPaged(int page, int pageSize)
    {
        var query = _dbContext.Destinations.Where(d => d.Request.Status == CheckpointRequestStatus.Accepted);
        var task = query.GetPaged<Destination>(page, pageSize);
        task.Wait();
        return task.Result;
    }
    
    public Result<PagedResult<Destination>> GetAllAdministratorDestinations(int page, int pageSize)
    {
        var query = _dbContext.Destinations.Where(d => d.Request != null);
        var task = query.GetPaged<Destination>(page, pageSize);
        task.Wait();
        return task.Result;
    }
}