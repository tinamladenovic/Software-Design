using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Route("api/author/destination")]
    public class DestinationController : BaseApiController
    {
        private readonly IDestinationService _destinationService;
        private readonly IDestinationRequestService _destinationRequestService;

        public DestinationController(IDestinationService destinationService, IDestinationRequestService destinationRequestService)
        {
            _destinationService = destinationService;
            _destinationRequestService = destinationRequestService;
        }

        [HttpGet]
        [Authorize(Policy = "authorPolicy")]
        public ActionResult<PagedResult<DestinationDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize) 
        {
            var result = _destinationService.GetPagedForAuthor(ClaimsPrincipalExtensions.PersonId(User), page, pageSize);
            return CreateResponse(result);
        }


        [HttpGet("{id:int}")]
        public ActionResult<DestinationDto> Get(int id)
        {
            var result = _destinationService.Get(id);
            return CreateResponse(result);
        }

        [HttpPost]
        [Authorize(Policy = "authorPolicy")]
        public ActionResult<DestinationDto> Create([FromBody] DestinationDto destination)
        {
            var result = _destinationService.Create(destination, ClaimsPrincipalExtensions.PersonId(User));
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Policy = "authorPolicy")]
        public ActionResult Delete(int id)
        {
            var result = _destinationService.Delete(id, ClaimsPrincipalExtensions.PersonId(User));
            return CreateResponse(result);
        }

        [HttpPut]
        [Authorize(Policy = "authorPolicy")]
        public ActionResult<DestinationDto> Update([FromBody] DestinationDto destination)
        {
            var result = _destinationService.Update(destination, ClaimsPrincipalExtensions.PersonId(User));
            return CreateResponse(result);
        }

        [HttpGet("public")]
        [AllowAnonymous]
        public ActionResult<PagedResult<DestinationDto>> GetAllPublic([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _destinationRequestService.GetPagedPublic(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPatch("{id:long}/accept")]
        [AllowAnonymous]
        [Authorize(Policy = "administratorPolicy")]
        public ActionResult Accept(long id)
        {
            var result = _destinationRequestService.Accept(id);
            return CreateResponse(result);
        }

        [HttpPatch("{id:long}/reject")]
        [AllowAnonymous]
        [Authorize(Policy = "administratorPolicy")]
        public ActionResult Reject(long id, [FromBody] string comment)
        {
            var result = _destinationRequestService.Reject(id, comment);
            return CreateResponse(result);
        }
        
        [HttpGet("administrator/destinations")]
        [AllowAnonymous]
        public ActionResult<PagedResult<DestinationDto>> GetAllAdministratorDestinations([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _destinationRequestService.GetAllAdministratorDestinations(page, pageSize);
            return CreateResponse(result);
        }
    }
}
