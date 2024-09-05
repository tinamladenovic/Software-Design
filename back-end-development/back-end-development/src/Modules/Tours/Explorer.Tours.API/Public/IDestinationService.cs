using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public
{
    public interface IDestinationService
    {
        Result<DestinationDto> Create(DestinationDto destination, long personId);
        Result<DestinationDto> Get(long id);
        Result<PagedResult<DestinationDto>> GetPaged(int page, int pageSize);
        Result<PagedResult<DestinationDto>> GetPagedForAuthor(long authorId, int page, int pageSize);
        Result Delete(int id, long personId);
        Result<DestinationDto> Update(DestinationDto destination, long personId);
        Result<PagedResult<DestinationDto>> GetPagedPublic(int page, int pageSize);
    }
}
