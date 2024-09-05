using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.API.Public.Administration;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases.Administration;

public class UserManagmentService : BaseService<UserDto, User>, IUserManagmentService
{
    private readonly IUserRepository _userRepository;

    public UserManagmentService(IMapper mapper, IUserRepository userRepository) :
        base(mapper)
    {
        _userRepository = userRepository;
    }
    
    public Result<PagedResult<UserDto>> GetPaged(int page, int pageSize)
    {
        return MapToDto(_userRepository.GetPaged(page, pageSize));
    }
    
    public Result<UserDto> Block(long id)
    {
        try
        {
            var result = _userRepository.BlockUser(id);
            return MapToDto(result);
        }
        catch (Exception e)
        {
            return Result.Fail(FailureCode.NotFound).WithError(e.Message);
        }
    }
}