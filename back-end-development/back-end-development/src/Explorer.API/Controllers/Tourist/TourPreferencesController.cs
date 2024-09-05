using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Tourist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/tourpreferences")]
    public class TourPreferencesController : BaseApiController
    {
        private readonly ITourPreferencesService _tourPreferencesService;

        public TourPreferencesController(ITourPreferencesService tourPreferencesService)
        {
            _tourPreferencesService = tourPreferencesService;
        }

        [HttpGet]
        public ActionResult<PagedResult<TourPreferencesDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourPreferencesService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<TourPreferencesDto> Create([FromBody] TourPreferencesDto tourPreference)
        {
            tourPreference.TouristId = ClaimsPrincipalExtensions.PersonId(User);
            var result = _tourPreferencesService.Create(tourPreference);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<TourPreferencesDto> Update([FromBody] TourPreferencesDto tourPreference)
        {
            tourPreference.TouristId = ClaimsPrincipalExtensions.PersonId(User);
            var result = _tourPreferencesService.Update(tourPreference);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _tourPreferencesService.Delete(id);
            return CreateResponse(result);
        }
    }
}

