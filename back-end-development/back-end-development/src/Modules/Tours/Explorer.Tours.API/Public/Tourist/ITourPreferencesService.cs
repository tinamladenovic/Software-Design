using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;

namespace Explorer.Tours.API.Public.Tourist;

public interface ITourPreferencesService
{
    Result<PagedResult<TourPreferencesDto>> GetPaged(int page, int pageSize);
    Result<TourPreferencesDto> Create(TourPreferencesDto tourPreferences);
    Result<TourPreferencesDto> Update(TourPreferencesDto tourPreferences);
    Result Delete(int id);
    Result<PagedResult<TourPreferencesDto>> GetTourId(long tourId, int page, int pageSize);
    Result<TourPreferencesDto> GetByTourist(long touristId);
}
