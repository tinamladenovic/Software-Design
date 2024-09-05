using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Explorer.API.Controllers.Tourist.Club
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/clubrequest/requesttojoinclub")]
    public class RequestToJoinClubController : BaseApiController
    {
        private readonly IRequestToJoinClubService _requestToJoinClubService;
        
        public RequestToJoinClubController(IRequestToJoinClubService requestToJoinClubService)
        {
            _requestToJoinClubService = requestToJoinClubService;
        }

        [HttpGet]
        public ActionResult<PagedResult<EquipmentDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _requestToJoinClubService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }


        [HttpGet("{id:int}")]
        public ActionResult<RequestToJoinClubDto> Get(int id)
        {
            var result = _requestToJoinClubService.Get(id);
            return CreateResponse(result);
        }


        [HttpPost()]
        public ActionResult<RequestToJoinClubDto> Create([FromBody] RequestToJoinClubDto request)
        {
            Result<RequestToJoinClubDto> result = null;
            try
            {
                result = _requestToJoinClubService.Create(request);
            }
            catch (DbUpdateException ex)
            {
                result = Result.Fail(FailureCode.InvalidArgument).WithError("");
            }

            return CreateResponse(result);
        }

        [HttpPost("{id:int}"), DisableRequestSizeLimit]
        public ActionResult<RequestToJoinClubDto> Create(int id, [FromBody] RequestToJoinClubDto request)
        {
            request.TouristId = id;
            var result = _requestToJoinClubService.Create(request);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _requestToJoinClubService.Delete(id);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<RequestToJoinClubDto> Update([FromBody] RequestToJoinClubDto request)
        {
            var result = _requestToJoinClubService.Update(request);
            return CreateResponse(result);
        }
    }
}
