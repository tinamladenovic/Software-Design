using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;

namespace Explorer.Tours.API.Public;

public interface IDestinationRequestService
{
    Result<DestinationDto> Accept(long id);
    Result<DestinationDto> Reject(long id, string comment);
    Result<PagedResult<DestinationDto>> GetPagedPublic(int page, int pageSize);
    
    Result<PagedResult<DestinationDto>> GetAllAdministratorDestinations(int page, int pageSize);
}