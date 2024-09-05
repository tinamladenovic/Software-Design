using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Tourist
{
    public interface ICompositeTourService
    {
        Result<PagedResult<CompositeTourDto>> GetByTouristId(long touristId, int page, int pageSize);
        Result<CompositeTourDto> Create(CompositeTourDto compositeTour);
        Result<PagedResult<CheckpointDto>> GetCheckpoints(int page, int size, int compositeTourId);
        Result<CompositeTourDto> GetById(long id);
    }
}
