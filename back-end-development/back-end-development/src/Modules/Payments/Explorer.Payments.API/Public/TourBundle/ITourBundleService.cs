using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using FluentResults;

namespace Explorer.Payments.API.Public.TourBundle
{
    public interface ITourBundleService
    {
        Result<TourBundleDto> Get(long id);
        Result<PagedResult<TourBundleDto>> GetByTour(long tourId, int page, int pageSize);
        Result<PagedResult<TourBundleDto>> GetAuthorBundles(long authorId, int page, int pageSize);
        Result<PagedResult<TourBundleDto>> GetAll(int page, int pageSize);
        Result<TourBundleDto> Create(TourBundleDto tourBundle);
        Result<TourBundleDto> Archieve(long tourBundleId);
        Result<TourBundleDto> Publish(long id);
        Result<TourBundleDto> Update(TourBundleDto tourBundle);
        Result<bool> CheckCanPublish(long id);
    }
}
