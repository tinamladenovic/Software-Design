using Explorer.Stakeholders.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.API.Internal
{
    public interface IInternalUserService
    {
        Result<UserDto> GetUser(long userId);
    }
}
