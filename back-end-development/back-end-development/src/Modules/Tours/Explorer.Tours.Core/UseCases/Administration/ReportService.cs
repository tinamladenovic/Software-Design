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
    public class ReportService : CrudService<ReportDto, Report>, IReportService
    {
        protected readonly IReportRepository _reportRepository;

        public ReportService(ICrudRepository<Report> crudRepository, IMapper mapper, IReportRepository reportRepository) : base(crudRepository, mapper)
        {
            _reportRepository = reportRepository;
        }

        
        public Result<PagedResult<ReportDto>> GetAll()
        {
            var result = _reportRepository.GetAll();
            return MapToDto(result);
        }
    }
}
