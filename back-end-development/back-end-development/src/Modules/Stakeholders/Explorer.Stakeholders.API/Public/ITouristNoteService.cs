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
    public interface ITouristNoteService
    {
        Result<PagedResult<TouristNoteDto>> GetPaged(int page, int pageSize);
        Result<TouristNoteDto> Create(TouristNoteDto touristNote);
        Result<TouristNoteDto> Update(TouristNoteDto touristNote);
        Result<PagedResult<TouristNoteDto>> GetPagedForTourist(int id, int page, int pageSize);
        Result Delete(int id);
    }
}
