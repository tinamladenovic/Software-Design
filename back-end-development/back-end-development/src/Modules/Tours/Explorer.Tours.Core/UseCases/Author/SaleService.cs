using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Author
{
    public class SaleService : CrudService<SaleDto, Sale>, ISaleService
    {
        private readonly ISaleRepository SaleRepository;
        private readonly ITourSaleConnectionRepository TourSaleConnectionRepository;
        public SaleService(ICrudRepository<Sale> crudRepository, ISaleRepository saleRepository, ITourSaleConnectionRepository tourSaleConnectionRepository, IMapper mapper) : base(crudRepository, mapper)
        {
            SaleRepository = saleRepository;
            TourSaleConnectionRepository = tourSaleConnectionRepository;
        }
        public Result<List<SaleDto>> GetAllForAuthor(long Id)
        {
            return MapToDto(SaleRepository.GetAllForAuthor(Id));
        }
        public Result<SaleDto> CreateWithRestrictions(SaleDto sale)
        {
            bool isElegableForAdding = true;
            if (sale.StartDate<DateTime.Now)
            {
                isElegableForAdding = false;
            }
            if (sale.StartDate < sale.EndDate.AddDays(-14))
            {
                isElegableForAdding = false;
            }
            if (isElegableForAdding)
            {
                try
                {
                    var result = SaleRepository.Create(MapToDomain(sale));
                    return MapToDto(result);
                }
                catch (ArgumentException e)
                {
                    return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
                }
            }
            else
            {
                return Result.Fail(FailureCode.InvalidArgument);
            }
        }
        public Result<bool> DeleteCascade(int id) 
        {
            List<TourSaleConnection> tourSalesConnections = TourSaleConnectionRepository.GetAllForSale(id);
            foreach (TourSaleConnection tsc in tourSalesConnections)
            {
                TourSaleConnectionRepository.Delete(tsc.Id);
            }
            Delete(id);
            return true;
        }
        public Result<SaleDto> GetSaleForTourId(long id) 
        {
            List<TourSaleConnection> tourSalesConnections = TourSaleConnectionRepository.GetAllForTour(id);
            foreach (TourSaleConnection tsc in tourSalesConnections) 
            {
                Sale sale = SaleRepository.GetById(tsc.SaleId);
                if (sale.StartDate < DateTime.Now && sale.EndDate > DateTime.Now) 
                {
                    return MapToDto(sale);
                }
            }
            return Result.Fail(FailureCode.InvalidArgument);
        }
    }
}
