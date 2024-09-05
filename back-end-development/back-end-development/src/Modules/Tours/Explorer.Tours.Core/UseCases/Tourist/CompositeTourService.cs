using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.UseCases.Author;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Tourist
{
    public class CompositeTourService : CrudService<CompositeTourDto, CompositeTour>, ICompositeTourService
    {
        protected readonly ICompositeTourRepository _compositeTourRepository;
        protected readonly IMapper _mapper;

        public CompositeTourService(IMapper mapper, ICrudRepository<CompositeTour> repository, ICompositeTourRepository compositeTourRepository) : base(repository,mapper)
        {
            _compositeTourRepository = compositeTourRepository;
            _mapper = mapper;
        }

        public Result<PagedResult<CompositeTourDto>> GetByTouristId(long touristId, int page, int pageSize)
        {
            var result = _compositeTourRepository.GetByTouristId(touristId, page, pageSize);
            return MapToDto(result);
        }

        public Result<CompositeTourDto> GetById(long id)
        {
            var result = _compositeTourRepository.GetById(id);
            return MapToDto(result.Value);
        }

        public Result<PagedResult<CheckpointDto>> GetCheckpoints(int page, int size, int compositeTourId)
        {
            Result<CompositeTour> result = _compositeTourRepository.GetById(compositeTourId);
            CompositeTourDto compositeTourDto = MapToDto(result.Value);

            List<CheckpointDto> checkpoints = compositeTourDto.Checkpoints;
            

            int count = checkpoints.Count();

            return new PagedResult<CheckpointDto>(checkpoints,count);

        }
    }
}
