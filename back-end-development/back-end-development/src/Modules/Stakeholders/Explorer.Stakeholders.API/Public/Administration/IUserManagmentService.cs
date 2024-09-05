using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.API.Public.Administration;

public interface IUserManagmentService
{
    Result<PagedResult<UserDto>> GetPaged(int page, int pageSize);
    Result<UserDto> Block(long id);
}