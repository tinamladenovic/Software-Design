using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IDestinationRepository : ICrudRepository<Destination>
    {
        PagedResult<Destination> GetPagedForAuthor(long authorId, int page, int pageSize);
    }
}
