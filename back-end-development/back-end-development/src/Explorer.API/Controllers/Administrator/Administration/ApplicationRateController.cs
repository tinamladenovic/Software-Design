namespace Explorer.API.Controllers.Administrator.Administration
{
    using Explorer.BuildingBlocks.Core.UseCases;
    using Explorer.Stakeholders.API.Dtos;
    using Explorer.Stakeholders.API.Public;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/administration/[controller]")]
    public class ApplicationRateController : BaseApiController
    {
        private readonly IApplicationRateService _applicationRateService;

        public ApplicationRateController(IApplicationRateService ApplicationRateService)
        {
            _applicationRateService = ApplicationRateService;
        }


        [Authorize(Policy = "administratorPolicy")]
        [HttpGet]
        public ActionResult<PagedResult<ApplicationRateDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _applicationRateService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }


        [Authorize(Policy = "touristPolicy")]
        [HttpPost]
        public ActionResult<ApplicationRateDto> Create([FromBody] ApplicationRateDto applicationRate)
        {
            applicationRate.PersonId = HttpContext.GetPersonId();
            applicationRate.CreationTime = DateTime.UtcNow;
            var result = _applicationRateService.Create(applicationRate);
            return CreateResponse(result);
        }

        [Authorize(Policy = "touristPolicy")]
        [HttpPut("{id:int}")]
        public ActionResult<ApplicationRateDto> Update([FromBody] ApplicationRateDto applicationRate)
        {
            var result = _applicationRateService.Update(applicationRate);
            return CreateResponse(result);
        }

        [Authorize(Policy = "touristPolicy")]
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _applicationRateService.Delete(id);
            return CreateResponse(result);
        }
    }
}
