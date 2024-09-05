using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public.TourBundle;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Microsoft.AspNetCore.Mvc.Route("api/author/tourBundle")]
    public class TourBundleController : BaseApiController
    {
        private readonly ITourBundleService _tourBundleService;
        public TourBundleController(ITourBundleService tourBundleService)
        {
            _tourBundleService = tourBundleService;
        }
        [HttpGet("{id:int}")]
        public ActionResult<TourBundleDto> Get(int id)
        {
            var result = _tourBundleService.Get(id);
            return CreateResponse(result);
        }

        

        [HttpGet]
        public ActionResult<PagedResult<TourBundleDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourBundleService.GetAuthorBundles(ClaimsPrincipalExtensions.PersonId(User), page, pageSize);
            return CreateResponse(result);
        }
        [HttpPost()]
        public ActionResult<TourBundleDto> Create([FromBody] TourBundleDto tourBundleDto)
        {
            tourBundleDto.AuthorId = ClaimsPrincipalExtensions.PersonId(User);
            var result = _tourBundleService.Create(tourBundleDto);
            return CreateResponse(result);
        }

        [HttpPatch("publish/{id:int}")]
        public ActionResult<TourBundleDto> Publish(int id)
        {
            var result = _tourBundleService.Publish((long)id);
            return CreateResponse(result);
        }
        [HttpPatch("archieve/{id:int}")]
        public ActionResult<TourBundleDto> Archieve(int id)
        {
            var result = _tourBundleService.Archieve((long)id);
            return CreateResponse(result);
        }
    }
}
