using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/users/allUsers")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("ClubMembers/{clubId:int}/{logedInId:int}")]
        public ActionResult<List<UserDto>> GetClubMembers(long clubId, long logedInId)
        {
            var result = _userService.GetClubMembers(clubId, logedInId);
            return CreateResponse(result);
        }
        [HttpGet("NonClubMembers/{clubId:int}/{logedInId:int}")]
        public ActionResult<List<UserDto>> GetNonClubMembers(long clubId, long logedInId)
        {
            var result = _userService.GetNonClubMembers(clubId, logedInId);
            return CreateResponse(result);
        }
        [HttpGet("NotFollowing/{logedInId:int}")]
        public ActionResult<List<UserDto>> GetNotFollowing(long logedInId)
        {
            var result = _userService.GetNotFollowing(logedInId);
            return CreateResponse(result);
        }
        [HttpGet("GetAll/{logedInId:int}")]
        public ActionResult<List<UserDto>> GetAllExceptCurrent(long logedInId)
        {
            var result = _userService.GetAllExceptCurrent(logedInId);
            return CreateResponse(result);
        }
        [HttpGet("GetById/{userId:int}")]
        public ActionResult<UserDto> GetById(long userId)
        {
            var result = _userService.GetById(userId);
            return CreateResponse(result);
        }
    }
}
