using FluentResults;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.Core.Domain.TourPackages;

namespace Explorer.Payments.Core.Domain.RepositoryInterfaces
{
    public interface ITourBundleRepository
    {
        Result<PagedResult<TourBundle>> GetAll(int page, int pageSize, long authorId);
        Result<PagedResult<TourBundle>> GetAll(int page, int pageSize);
        Result<PagedResult<TourBundle>> GetByTour(long tourId, int page, int pageSize);
        TourBundle Get(long id);
        TourBundle Create(TourBundle tourBundle);
        TourBundle Update(TourBundle tourBundle);
        void Delete(long id);
    }
}
