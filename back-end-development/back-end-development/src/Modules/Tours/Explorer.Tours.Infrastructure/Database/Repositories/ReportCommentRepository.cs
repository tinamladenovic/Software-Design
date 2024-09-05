using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class ReportCommentRepository : IReportCommentRepository
    {
        protected readonly ToursContext DbContext;
        private readonly DbSet<ReportComment> _dbSet;

        public ReportCommentRepository(ToursContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<ReportComment>();
        }

        public PagedResult<ReportComment> GetPagedForReport(int reportId, int page, int pageSize)
        {
            var task = _dbSet.Where<ReportComment>(comment => comment.ReportId == reportId).GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

    }
}
