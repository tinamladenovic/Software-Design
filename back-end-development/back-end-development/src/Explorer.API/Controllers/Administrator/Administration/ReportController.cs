using Microsoft.AspNetCore.Mvc;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Explorer.Stakeholders.API.Dtos;

namespace Explorer.API.Controllers.Administrator.Administration
{
    [Route("api/administration/report")]

    public class ReportController : BaseApiController
    {
        private readonly IReportService _reportService;
        private readonly IReportCommentService _reportCommentService;

        public ReportController(IReportService reportService, IReportCommentService reportCommentService)
        {
            _reportService = reportService;
            _reportCommentService = reportCommentService;
        }

        [HttpGet]
        public ActionResult<PagedResult<ReportDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _reportService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("/api/administration/report/{id:int}")]
        public ActionResult<PagedResult<ReportCommentDto>> GetAllReportComments(int id, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _reportCommentService.GetPagedForReport(id, page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost("/api/administration/report")]
        public ActionResult<ReportCommentDto> Create([FromBody] ReportCommentDto reportComment)
        {
            var result = _reportCommentService.Create(reportComment);
            return CreateResponse(result);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _reportService.Delete(id);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}/1")]
        public ActionResult DeleteComment(int id)
        {
            var result = _reportCommentService.Delete(id);
            return CreateResponse(result);
        }
    }
}
