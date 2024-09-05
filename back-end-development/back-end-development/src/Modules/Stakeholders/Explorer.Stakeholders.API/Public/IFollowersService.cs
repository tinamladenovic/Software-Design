using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public
{
    public interface IFollowersService
    {
        Result<PagedResult<FollowersDto>> GetPaged(int page, int pageSize);
        Result<FollowersDto> Create(FollowersDto followers);
        Result Delete(long followedId, long followingId);
        Result<FollowersDto> GetById(long followedId, long followingId);
        List<long> GetFollowingForUser(long userId);
    }
}
