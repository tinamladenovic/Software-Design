using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Club
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/club/clubUsers")]
    public class ClubUsersController : BaseApiController
    {
        private readonly IClubUsersService _clubUsersService;

        public ClubUsersController(IClubUsersService clubUsersService)
        {
            _clubUsersService = clubUsersService;
        }
        [HttpPost]
        public ActionResult<ClubUsersDto> Create([FromBody] ClubUsersDto request)
        {
            var result = _clubUsersService.Create(request);
            return CreateResponse(result);
        }
        [HttpDelete("{clubId:int}/{userId:int}")]
        public ActionResult Delete(long clubId, long userId)
        {
            var result = _clubUsersService.Delete(clubId, userId);
            return CreateResponse(result);
        }

    }
}
