using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases
{
    public class TouristEquipmentService : BaseService<TouristEquipmentDTO, TouristEquipment>,  ITouristEquipmentService
    {
        private readonly ITouristEquipmentRepository _touristEquipmentRepository;
        public TouristEquipmentService(IMapper mapper, ITouristEquipmentRepository touristEquipmentRepository) : base(mapper) 
        {
            _touristEquipmentRepository = touristEquipmentRepository;
        }

        Result<TouristEquipmentDTO> ITouristEquipmentService.Create(TouristEquipmentDTO touristEquipment)
        {
            return MapToDto(_touristEquipmentRepository.Create(MapToDomain(touristEquipment)));
        }

        Result ITouristEquipmentService.Delete(long id)
        {
            _touristEquipmentRepository.Delete(id);
            return Result.Ok();
        }

        Result<PagedResult<TouristEquipmentDTO>> ITouristEquipmentService.GetPaged(int page, int pageSize)
        {
            var result = _touristEquipmentRepository.GetPaged(page, pageSize);
            return MapToDto(result);
        }

        Result<PagedResult<TouristEquipmentDTO>> ITouristEquipmentService.GetPagedById(int page, int pageSize, long id)
        {
            return MapToDto(_touristEquipmentRepository.GetPagedById(page, pageSize, id));
        }
    }
}
