using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/followers/users")]
    public class FollowersController : BaseApiController
    {
        private readonly IFollowersService _followersService;

        public FollowersController(IFollowersService followersService)
        {
            _followersService = followersService;
        }

        [HttpGet]
        public ActionResult<PagedResult<FollowersDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _followersService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<FollowersDto> Create([FromBody] FollowersDto request)
        {
            //var result = _followersService.Create(request);
            //return CreateResponse(result);
            Result<FollowersDto> result = null;
            try
            {
                result = _followersService.Create(request);
            }
            catch (DbUpdateException ex)
            {
                result = Result.Fail(FailureCode.InvalidArgument).WithError("");
            }

            return CreateResponse(result);
        }

        [HttpDelete("{followedId:int}/{followingId:int}")]
        public ActionResult Delete(long followedId, long followingId)
        {
            var result = _followersService.Delete(followedId, followingId);
            return CreateResponse(result);
        }

        [HttpGet("GetFollowersById/{followedId:int}/{followingId:int}")]
        public ActionResult<UserDto> GetById(long followedId, long followingId)
        {
            var result = _followersService.GetById(followedId, followingId);
            return CreateResponse(result);
        }

        [HttpGet("GetFollowingForUser/{followingId:int}")]
        public List<long> GetFollowingForUser(long followingId)
        {
            var result = _followersService.GetFollowingForUser(followingId);
            return result;
        }
    }
}
