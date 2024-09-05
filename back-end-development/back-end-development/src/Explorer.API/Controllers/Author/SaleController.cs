using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/sale")]
    public class SaleController : BaseApiController
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public ActionResult<PagedResult<SaleDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _saleService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<SaleDto> Create([FromBody] SaleDto request)
        {
            Result<SaleDto> result = null;
            try
            {
                result = _saleService.CreateWithRestrictions(request);
            }
            catch (DbUpdateException ex)
            {
                result = Result.Fail(FailureCode.InvalidArgument).WithError("");
            }

            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<SaleDto> Update([FromBody] SaleDto request)
        {
            var result = _saleService.Update(request);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _saleService.DeleteCascade(id);
            return CreateResponse(result);
        }

        [HttpGet("GetAllForAuthor/{id:int}")]
        public ActionResult<List<SaleDto>> GetAllForAuthor(long id)
        {
            var result = _saleService.GetAllForAuthor(id);
            return CreateResponse(result);
        }
        [HttpGet("GetSaleForTourId/{Id:int}")]
        public ActionResult<SaleDto> GetNotFollowing(long Id)
        {
            var result = _saleService.GetSaleForTourId(Id);
            return CreateResponse(result);
        }
    }
}
