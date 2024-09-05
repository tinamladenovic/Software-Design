using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ICompositeTourRepository
    {
        Result<PagedResult<CompositeTour>> GetByTouristId(long touristId, int page, int pageSize);
        Result<CompositeTour> GetById(long id);
    }
}
