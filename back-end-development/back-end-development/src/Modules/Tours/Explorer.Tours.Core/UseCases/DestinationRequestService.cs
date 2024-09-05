using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Tours.Core.UseCases;

public class DestinationRequestService : BaseService<DestinationDto, Destination>, IDestinationRequestService
{
    private IDestinationRequestDatabaseRepository _repository;

    public DestinationRequestService(IMapper mapper, IDestinationRequestDatabaseRepository repository) : base(mapper)
    {
        _repository = repository;
    }

    public Result<DestinationDto> Accept(long id)
    {
        var result = _repository.Accept(id);
        return MapToDto(result.Value);
    }

    public Result<DestinationDto> Reject(long id, string comment)
    {
        var result = _repository.Reject(id, comment);
        return MapToDto(result.Value);
    }

    public Result<PagedResult<DestinationDto>> GetPagedPublic(int page, int pageSize)
    {
        var result = _repository.GetPublicPaged(page, pageSize);
        return MapToDto(result);
    }
    
    public Result<PagedResult<DestinationDto>> GetAllAdministratorDestinations(int page, int pageSize)
    {
        var result = _repository.GetAllAdministratorDestinations(page, pageSize);
        return MapToDto(result);
    }
}