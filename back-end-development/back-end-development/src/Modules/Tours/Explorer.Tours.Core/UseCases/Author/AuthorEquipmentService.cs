using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Tours.Core.Domain;
using AutoMapper;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Explorer.Tours.API.Public.Author;

namespace Explorer.Tours.Core.UseCases.Author
{
    public class AuthorEquipmentService : CrudService<EquipmentDto,Equipment>, IAuthorEquipmnetService
    {
        protected readonly IAuthorEquipmentRepository _authorEquipmnetRepository;
        public AuthorEquipmentService(ICrudRepository<Equipment> repository, IMapper mapper, IAuthorEquipmentRepository authorEquipmnetRepository) : base(repository, mapper)
        {
            _authorEquipmnetRepository = authorEquipmnetRepository;
        }

        /* public Result<PagedResult<EquipmentDto>> GetEquipmentByTourId(int tourId, int page, int pageSize)
         {
             var result = _authorEquipmnetRepository.GetEquipmentByTourId(tourId, page, pageSize);
             return MapToDto(result);
         }*/
    }
}
