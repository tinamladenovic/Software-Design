using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public.TourBundle;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Core.Domain.TourPackages;
using Explorer.Tours.API.Internal;
using Explorer.Tours.API.Public.Author;
using FluentResults;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Explorer.Tours.Core.UseCases.Author
{
    public class TourBundleService : BaseService<TourBundleDto, TourBundle>, ITourBundleService
    {
        protected readonly ITourBundleRepository _tourBundleRepository;
        protected readonly IInternalTourService _tourService;

        public TourBundleService(IMapper mapper, ITourBundleRepository tourBundleRepository, IInternalTourService tourService) : base(mapper)
        {
            _tourBundleRepository = tourBundleRepository;
            _tourService = tourService;
        }

        public Result<TourBundleDto> Get(long id)
        {
            try
            {
                var result = _tourBundleRepository.Get(id);
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<PagedResult<TourBundleDto>> GetByTour(long tourId, int page, int pageSize)
        {
            try
            {
                var bundles = _tourBundleRepository.GetByTour(tourId, page, pageSize);
                return MapToDto(bundles);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<PagedResult<TourBundleDto>> GetAuthorBundles(long authorId, int page, int pageSize)
        {
            try
            {
                var bundles = _tourBundleRepository.GetAll(page, pageSize, authorId);
                return MapToDto(bundles);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<PagedResult<TourBundleDto>> GetAll(int page, int pageSize)
        {
            try
            {
                var bundles = _tourBundleRepository.GetAll(page, pageSize);
                return MapToDto(bundles);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<TourBundleDto> Create(TourBundleDto tourBundle)
        {
            try
            {
                var bundle = MapToDomain(tourBundle);
                var result = _tourBundleRepository.Create(bundle);
                return MapToDto(result);
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.Internal).WithError(ex.Message);
            }
        }

        public Result<TourBundleDto> Archieve(long tourBundleId)
        {
            try
            {
                var tourBundle = _tourBundleRepository.Get(tourBundleId);
                tourBundle.ArchivePackage();
                _tourBundleRepository.Update(tourBundle);
                return MapToDto(tourBundle);
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.Internal).WithError(ex.Message);
            }
        }

        public Result<TourBundleDto> Publish(long id)
        {
            try
            {
                var tourBundle = _tourBundleRepository.Get(id);
                tourBundle.PublishPackage();
                _tourBundleRepository.Update(tourBundle);
                return MapToDto(tourBundle);
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.Internal).WithError(ex.Message);
            }
        }


        public Result<TourBundleDto> Update(TourBundleDto tourBundle)
        {
            var tour = MapToDomain(tourBundle);
            var result = _tourBundleRepository.Update(tour);
            return MapToDto(result);
        }

        public Result<bool> CheckCanPublish(long id)
        {
            try
            {
                var tourBundle = _tourBundleRepository.Get(id);
                var counter = 0;
                foreach (TourStatus status in tourBundle.Tours)
                {
                    var tour = _tourService.GetById(status.TourId);
                    if (tour.Value.Status == API.Dtos.Status.PUBLISHED) counter++;
                }

                return counter > 1;

            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.Internal).WithError(ex.Message);
            }
        }

        
    }
}
