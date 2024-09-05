using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Internal;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Internal;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using Status = Explorer.Tours.API.Dtos.Status;

namespace Explorer.Tours.Core.UseCases.Author
{
    public class TourService : CrudService<TourDto, Tour>, ITourService, IInternalTourService
    {
        protected readonly ITourRepository _tourRepository;
        protected readonly IInternalOrderService _orderService;
        protected readonly IInternalShoppingCartService _shoppingCartService;
        protected readonly IInternalShoppingSession _shoppingSession;
        protected readonly IMapper _mapper;

        public TourService(ICrudRepository<Tour> repository, IInternalOrderService orderService, IMapper mapper,
            ITourRepository tourRepository, IInternalShoppingCartService shoppingCartService,IInternalShoppingSession shoppingSession) : base(repository, mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
            _shoppingSession = shoppingSession;
        }


        public Result<PagedResult<TourDto>> GetByAuthorId(long authorId, int page, int pageSize)
        {
            var result = _tourRepository.GetByAuthorId(authorId, page, pageSize);
            return MapToDto(result);
        }

        public Result<PagedResult<TourDto>> GetPublishedAuthorTours(long authorId, int page, int pageSize)
        {
            var result = _tourRepository.GetPublishedAuthorTours(authorId, page, pageSize);
            return MapToDto(result);
        }

        public void AddCheckpoint(CheckpointDto checkpoint, int tourId)
        {
            Tour tour = CrudRepository.Get(tourId);
            Checkpoint chekpointToAdd = new Checkpoint(checkpoint.Name, checkpoint.Description, checkpoint.PictureURL,
                new Coordinate(checkpoint.Latitude, checkpoint.Longitude), tourId);
            tour.AddCheckpoint(chekpointToAdd);
            CrudRepository.Update(tour);

        }

        public Result<TourDto> GetById(long id)
        {
            var result = _tourRepository.GetById(id);
            return MapToDto(result);
        }

        public Result<List<TourDto>> ReturnToursInRange(List<TourDto> tours)
        {
            Result<List<Tour>> ture = MapToDomain(tours);
            return MapToDto(ture);
        }

        

        public Result<PagedResult<TourPreviewDto>> GetAllAvailableTours(int page, int pageSize, int userId)
        {
            var result = _tourRepository.GetAllAvailableTours(page, pageSize);
            var ordered = _orderService.GetByUser(page, pageSize, userId);
            var cart = _shoppingCartService.GetCartByUserId(userId);

            //if (!_shoppingSession.CheckActiveShoppingSession(cart.Value.Id)) {
            //    _shoppingSession.OpenShoppingSession(cart.Value.Id);
            //}

            var dtos = result.Value.Results.Select(r => _mapper.Map<TourPreviewDto>(r)).ToList();

            var orderedIdsToRemove =
                ordered.Value.Results.Where(o => o.UserId == userId).Select(o => o.TourId).ToList();
            if (orderedIdsToRemove.Count > 0)
            {
                dtos.RemoveAll(p => orderedIdsToRemove.Contains(p.Id));
            }


            if (cart.Value != null)
            {
                var idsInCart = cart.Value.Items.Select(t => t.TourId).ToList();

                if (idsInCart.Count > 0)
                {
                    dtos.RemoveAll(p => idsInCart.Contains(p.Id));
                }
            }

            foreach (var tour in dtos)
            {
                var res = result.Value.Results.FirstOrDefault(t => t.Id == tour.Id);
                if (res != null)
                {
                    tour.IsFavorite = res.IsFavourite(userId);
                }
            }

            //Ovde postoji problem nakon izmestanja modula, treba to resiti

            //var idsInCart = cart.Value.Items.Select(t => t.TourId).ToList();

            //if (idsInCart.Count > 0)
            //{
            //    dtos.RemoveAll(p => idsInCart.Contains(p.Id));
            //}


            return new PagedResult<TourPreviewDto>(dtos, dtos.Count);
        }


        public Result<PagedResult<TourPreviewDto>> GetTouristTours(int page, int pageSize, long userId)
        {
            var orders = _orderService.GetByUser(page, pageSize, userId);
            if (orders == null)
            {
                return new PagedResult<TourPreviewDto>(new List<TourPreviewDto>(), 0);
            }

            var list = new List<TourPreviewDto>();
            var userTours = orders.Value.Results.Where(o => o.UserId == userId);
            foreach (var item in userTours)
            {
                Tour tour = _tourRepository.GetById(item.TourId);
                list.Add(_mapper.Map<TourPreviewDto>(tour));
            }

            return new PagedResult<TourPreviewDto>(list, list.Count);
        }

        public void PublishTour(int tourId, DateTime publishTime)
        {

            Tour tour = CrudRepository.Get(tourId);
            if (tour != null)
            {
                tour.Status = Explorer.Tours.Core.Domain.Tours.Status.PUBLISHED;
                tour.PublishTime = publishTime;
                CrudRepository.Update(tour);
            }
            else
            {
                throw new Exception("Tour not found");
            }

        }

        public void ArchiveTour(int tourId, DateTime archiveTime)
        {
            Tour tour = CrudRepository.Get(tourId);
            if (tour != null)
            {
                tour.Status = Explorer.Tours.Core.Domain.Tours.Status.ARCHIVED;
                tour.ArchiveTime = archiveTime;
                CrudRepository.Update(tour);
            }
            else
            {
                throw new Exception("Tour not found");
            }
        }

        public Result<PagedResult<TourDto>> GetSuggestions(int page, int pageSize, long[] checkpoints)
        {
            var result = _tourRepository.GetSuggestions(page, pageSize, checkpoints);
            return MapToDto(result);
        }

        public void AddCheckpoints(List<int> checkpoints, int tourId)
        {
            _tourRepository.AddCheckpoints(checkpoints, tourId);
        }

        public Result<List<TourDto>> ExtractPreferredTours(TourPreferencesDto preferences)
        {
            var tours = _tourRepository.GetAll();
            var result = tours.Where(t =>
                t.Difficult.ToString().ToLower() == preferences.TourDifficult.ToString().ToLower() &&
                t.Tags.Contains(preferences.Tags)).ToList();

            return MapToDto(result);
        }

        public Result<PagedResult<TourDto>> GetAllPublished(int page, int pageSize)
        {
            throw new NotImplementedException();
        }
        
        public void AddFavoriteTour(int touristId, int tourId)
        {
            _tourRepository.AddFavoriteTour(touristId, tourId);
        }

        public void RemoveFavoriteTour(int touristId, int tourId)
        {
            _tourRepository.RemoveFavoriteTour(touristId, tourId);
        }
    }
}


