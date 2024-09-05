using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public
{
    public interface IRequestToJoinClubService
    {
        Result<PagedResult<RequestToJoinClubDto>> GetPaged(int page, int pageSize);
        Result<RequestToJoinClubDto> Get(long id);
        Result<RequestToJoinClubDto> Create(RequestToJoinClubDto request);
        Result Delete(int id);
        Result<RequestToJoinClubDto> Update(RequestToJoinClubDto request);
    }
}
