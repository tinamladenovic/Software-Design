using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Author
{
    public interface IAuthorEquipmnetService
    {
        Result<PagedResult<EquipmentDto>> GetPaged(int page, int pageSize);
        Result<EquipmentDto> Create(EquipmentDto equipment);
        Result Delete(int id);
        //Result<PagedResult<EquipmentDto>> GetEquipmentByTourId(int tourId, int page, int pageSize);
    }
}
