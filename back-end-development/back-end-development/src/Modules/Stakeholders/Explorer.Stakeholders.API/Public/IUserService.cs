using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public
{
    public interface IUserService
    {
        Result<List<UserDto>> GetClubMembers(long clubId, long logedInId);
        Result<List<UserDto>> GetNonClubMembers(long clubId, long logedInId);
        Result<List<UserDto>> GetNotFollowing(long logedInId);
        Result<List<UserDto>> GetAllExceptCurrent(long logedInId);
        Result<UserDto> GetById(long userId);
    }
}
