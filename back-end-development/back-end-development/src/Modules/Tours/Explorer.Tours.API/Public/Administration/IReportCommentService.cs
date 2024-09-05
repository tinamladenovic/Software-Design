using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Administration
{
    public interface IReportCommentService
    {
        Result<PagedResult<ReportCommentDto>> GetPaged(int page, int pageSize);
        Result<ReportCommentDto> Create(ReportCommentDto dto);
        Result<PagedResult<ReportCommentDto>> GetPagedForReport(int id, int page, int pageSize);
        Result Delete(int id);
    }
}
