using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class TouristNoteService : CrudService<TouristNoteDto, TouristNote>, ITouristNoteService
    {
        private ITouristNotesRepository TouristNotesRepository;
        public TouristNoteService(ICrudRepository<TouristNote> repository, ITouristNotesRepository touristNotesRepository, IMapper mapper) : base(repository, mapper)
        {
            TouristNotesRepository = touristNotesRepository;
        }

        public Result<PagedResult<TouristNoteDto>> GetPagedForTourist(int touristId, int page, int pageSize)
        {
            var result = TouristNotesRepository.GetPagedForTourist(touristId, page, pageSize);
            return MapToDto(result);
        }
    }
}
