using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public
{
    public interface ITouristEquipmentService
    {
        Result<PagedResult<TouristEquipmentDTO>> GetPagedById(int page, int pageSize, long id);
        Result<PagedResult<TouristEquipmentDTO>> GetPaged(int page, int pageSize);
        Result<TouristEquipmentDTO> Create(TouristEquipmentDTO touristEquipment);
        Result Delete(long id);
    }
}
