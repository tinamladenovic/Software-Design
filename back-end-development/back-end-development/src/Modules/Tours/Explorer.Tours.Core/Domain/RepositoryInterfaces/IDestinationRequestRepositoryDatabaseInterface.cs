using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces;

public interface IDestinationRequestDatabaseRepository
{
    Result<Destination> Accept(long id);
    Result<Destination> Reject(long id, string comment);
    Result<PagedResult<Destination>> GetPublicPaged(int page, int pageSize);
    Result<PagedResult<Destination>> GetAllAdministratorDestinations(int page, int pageSize);
}