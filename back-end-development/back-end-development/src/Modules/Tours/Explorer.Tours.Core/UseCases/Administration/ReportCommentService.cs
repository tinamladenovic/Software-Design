using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Administration
{
    public class ReportCommentService : CrudService<ReportCommentDto, ReportComment>, IReportCommentService
    {
        protected readonly IReportCommentRepository _reportCommentRepository;

        public ReportCommentService(ICrudRepository<ReportComment> crudRepository, IMapper mapper, IReportCommentRepository reportCommentRepository) : base(crudRepository, mapper)
        {
            _reportCommentRepository = reportCommentRepository;
        }

        public Result<PagedResult<ReportCommentDto>> GetPagedForReport(int reportId, int page, int pageSize)
        {
            var result = _reportCommentRepository.GetPagedForReport(reportId, page, pageSize);
            return MapToDto(result);
        }


    }
}
