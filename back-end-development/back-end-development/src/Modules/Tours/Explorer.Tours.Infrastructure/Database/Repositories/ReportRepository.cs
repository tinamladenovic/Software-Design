using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ToursContext _context;

        public ReportRepository(ToursContext context)
        {
            _context = context;
        }


        public Result<PagedResult<Report>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
