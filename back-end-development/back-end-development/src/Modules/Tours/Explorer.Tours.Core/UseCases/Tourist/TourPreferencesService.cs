using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Tourist;

public class TourPreferencesService : CrudService<TourPreferencesDto, TourPreferences>, ITourPreferencesService
{

    protected readonly ITourPreferencesRepository _tourPreferencesRepository;
    public TourPreferencesService(ICrudRepository<TourPreferences> repository, IMapper mapper, ITourPreferencesRepository tourPreferencesRepository) : base(repository, mapper) {

        _tourPreferencesRepository = tourPreferencesRepository;
    }


    public Result<PagedResult<TourPreferencesDto>> GetTourId(long tourId, int page, int pageSize)
    {
        var result = _tourPreferencesRepository.GetByTourId(tourId, page, pageSize);
        return MapToDto(result);
    }

    public Result<TourPreferencesDto> GetByTourist(long touristId)
    {
        var result = _tourPreferencesRepository.GetByTouristId(touristId);
        return MapToDto(result.Value);
    }
}
