using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Author
{
    public class TourSaleConnectionService : CrudService<TourSaleConnectionDto, TourSaleConnection>, ITourSaleConnectionService
    {
        private readonly ITourSaleConnectionRepository TourSaleConnectionRepository;
        private readonly ISaleRepository SaleRepository;
        public TourSaleConnectionService(ICrudRepository<TourSaleConnection> crudRepository, ISaleRepository saleRepository, ITourSaleConnectionRepository tourSaleConnectionRepository, IMapper mapper) : base(crudRepository, mapper)
        {
            TourSaleConnectionRepository = tourSaleConnectionRepository;
            SaleRepository = saleRepository;
        }
        public Result<TourSaleConnectionDto> CreateWithRestrictions(TourSaleConnectionDto tourSaleConnection) 
        {
            bool isElegableForAdding = true;
            List<TourSaleConnection> tourSalesConnections = TourSaleConnectionRepository.GetAllForTour(tourSaleConnection.TourId);
            Sale sale = new Sale();
            try
            {
                sale = SaleRepository.GetById(tourSaleConnection.SaleId);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
            //sale = SaleRepository.GetById(tourSaleConnection.SaleId);
            foreach (TourSaleConnection tsc in tourSalesConnections) 
            {
                Sale saleTSC = SaleRepository.GetById(tsc.SaleId);
                if ((saleTSC.StartDate>sale.StartDate && saleTSC.StartDate<sale.EndDate) || (saleTSC.EndDate > sale.StartDate && saleTSC.EndDate < sale.EndDate))
                {
                    isElegableForAdding = false;
                }
            }
            if (isElegableForAdding)
            {
                try
                {
                    var result = TourSaleConnectionRepository.Create(MapToDomain(tourSaleConnection));
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
    }
}
