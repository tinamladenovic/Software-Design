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
    public interface IReportService
    {
        Result<PagedResult<ReportDto>> GetPaged(int page, int pageSize);
        Result<ReportDto> Create(ReportDto dto);
        Result<ReportDto> Update(ReportDto dto);
        Result Delete(int id);
        Result<PagedResult<ReportDto>> GetAll();
    }
}
