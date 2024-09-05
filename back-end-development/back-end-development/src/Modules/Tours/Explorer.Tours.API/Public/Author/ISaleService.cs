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
    public interface ISaleService
    {
        Result<PagedResult<SaleDto>> GetPaged(int page, int pageSize);
        Result<SaleDto> Create(SaleDto sale);
        Result<SaleDto> Update(SaleDto sale);
        Result Delete(int id);
        Result<List<SaleDto>> GetAllForAuthor(long Id);
        Result<SaleDto> CreateWithRestrictions(SaleDto sale);
        Result<bool> DeleteCascade(int id);
        Result<SaleDto> GetSaleForTourId(long id);
    }
}
