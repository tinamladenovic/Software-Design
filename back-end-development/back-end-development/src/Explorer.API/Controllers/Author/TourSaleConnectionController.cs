using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.Core.UseCases.Author;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/tourSaleConnection")]
    public class TourSaleConnectionController : BaseApiController
    {
        private readonly ITourSaleConnectionService _tourSaleConnectionService;
        public TourSaleConnectionController(ITourSaleConnectionService tourSaleConnectionService)
        {
            _tourSaleConnectionService = tourSaleConnectionService;
        }
        [HttpPost]
        public ActionResult<TourSaleConnectionDto> Create([FromBody] TourSaleConnectionDto request)
        {
            //var result = _tourSaleConnectionService.CreateWithRestrictions(request);
            //return CreateResponse(result);

            Result<TourSaleConnectionDto> result = null;
            try
            {
                result = _tourSaleConnectionService.CreateWithRestrictions(request);
            }
            catch (DbUpdateException ex)
            {
                result = Result.Fail(FailureCode.InvalidArgument).WithError("");
            }

            return CreateResponse(result);
        }
    }
}
