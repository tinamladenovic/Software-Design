using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Explorer.API.Controllers.Tourist.Club
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/sendinvite/clubrequest")]
    public class ClubRequestController: BaseApiController
    {
        private readonly IClubRequestService _clubRequestService;
        public ClubRequestController(IClubRequestService clubRequestService)
        {
            _clubRequestService = clubRequestService;
        }
        [HttpGet]
        public ActionResult<PagedResult<ClubRequestDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _clubRequestService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<ClubRequestDto> Create([FromBody] ClubRequestDto request)
        {
            request.Status = 0;
            Result<ClubRequestDto> result = null;
            try
            {
                result = _clubRequestService.Create(request);
            }catch (DbUpdateException ex)
            {
                result = Result.Fail(FailureCode.InvalidArgument).WithError("");
            }
            
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ClubRequestDto> Update([FromBody] ClubRequestDto request)
        {
            var result = _clubRequestService.Update(request);
            return CreateResponse(result);
        }

    }
}
