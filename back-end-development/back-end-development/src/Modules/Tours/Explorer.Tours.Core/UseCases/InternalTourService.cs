using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Internal;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;

namespace Explorer.Tours.Core.UseCases
{
    public class InternalTourService : BaseService<TourDto, Tour>, IInternalTourService
    {
        protected readonly ITourRepository _tourRepository;

        public InternalTourService(ITourRepository tourRepository, IMapper mapper) : base(mapper)
        {
            _tourRepository = tourRepository;
        }

        public Result<TourDto> GetById(long id)
        {
            var result = _tourRepository.GetById(id);
            return MapToDto(result);
        }
    }
}
