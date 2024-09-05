using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Administration
{
    public class EquipmentService : CrudService<EquipmentDto, Equipment>, IEquipmentService
    {
        private readonly ICrudRepository<Equipment> _repository;
        private readonly IMapper _mapper;

        public EquipmentService(ICrudRepository<Equipment> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
    

}