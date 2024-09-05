using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces;

public interface ITourPreferencesRepository
{
    Result<PagedResult<TourPreferences>> GetByTourId(long tourId, int page, int pageSize);
    Result<TourPreferences> GetByTouristId(long touristId);
}
