using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;


namespace Explorer.Tours.API.Public.Author
{
    public interface ITourService
    {
        Result<TourDto> Get(long id);
        Result<PagedResult<TourDto>> GetPaged(int page, int pageSize);
        Result<TourDto> Create(TourDto tour);
        Result<TourDto> Update(TourDto tour);
        Result Delete(int id);
        Result<PagedResult<TourDto>> GetByAuthorId(long authorId, int page, int pageSize);
        Result<PagedResult<TourDto>> GetPublishedAuthorTours(long authorId, int page, int pageSize);
        Result<TourDto> GetById(long id);
        void AddCheckpoint(CheckpointDto checkpoint, int tourId);
        void PublishTour(int tourId, DateTime publishTime);
        void ArchiveTour(int tourId, DateTime archiveTime);
        Result<PagedResult<TourPreviewDto>> GetAllAvailableTours(int page, int pageSize, int userId);
        Result<PagedResult<TourPreviewDto>> GetTouristTours(int page,int pageSize,long userId);
        Result<List<TourDto>> ReturnToursInRange(List<TourDto> tours);
        Result<PagedResult<TourDto>> GetSuggestions(int page, int pageSize, long[] checkpoints);
        void AddCheckpoints(List<int> checkpoints, int tourId);
        Result<List<TourDto>> ExtractPreferredTours(TourPreferencesDto preferences);
        Result<PagedResult<TourDto>> GetAllPublished(int page, int pageSize);
        void AddFavoriteTour(int touristId, int tourId);
        void RemoveFavoriteTour(int touristId, int tourId);
    }
}
