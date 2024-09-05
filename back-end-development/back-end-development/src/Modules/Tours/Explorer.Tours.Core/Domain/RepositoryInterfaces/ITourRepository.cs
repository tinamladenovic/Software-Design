using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ITourRepository
    {
        Result<PagedResult<Tour>> GetByAuthorId(long authorId, int page, int pageSize);
        Result<PagedResult<Tour>> GetPublishedAuthorTours(long authorId, int page, int pageSize);
        Result<PagedResult<Tour>> GetAllAvailableTours(int page, int pageSize);
        Tour GetById(long id);
        Result<PagedResult<Tour>> GetSuggestions(int page, int pageSize, long[] checkpoints);
        void AddCheckpoints(List<int> checkpoints, int tourId);
        long GetRandomTourAuthorByTour();
        IEnumerable<Tour> GetAll();
        void AddFavoriteTour(int touristId, int tourId);
        void RemoveFavoriteTour(int touristId, int tourId);
    }
}
