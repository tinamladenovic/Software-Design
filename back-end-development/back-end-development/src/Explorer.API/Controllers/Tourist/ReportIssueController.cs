using Microsoft.AspNetCore.Mvc;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourism/report")]
    public class ReportIssueController : BaseApiController
    {
        private readonly IReportService _reportService;

        public ReportIssueController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public ActionResult<ReportDto> Create([FromBody] ReportDto report) 
        {
            var result = _reportService.Create(report);
            return CreateResponse(result);
        }
    }
}
