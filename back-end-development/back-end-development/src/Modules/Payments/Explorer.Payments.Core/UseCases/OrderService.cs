using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Internal;
using Explorer.Payments.API.Public.ShoppingCart;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.API.Internal;
using FluentResults;

namespace Explorer.Payments.Core.UseCases
{
    public class OrderService : BaseService<OrderDto, Order>, IOrderService, IInternalOrderService
    {
        protected readonly IOrderRepository _orderRepository;
        protected readonly IWalletService _walletService;
        protected readonly IShoppingCartService _shoppingCartService;
        protected readonly IInternalTourService _internalTourService;
        protected readonly IHttpClientService _httpClientService;

        public OrderService(IOrderRepository orderRepository, IWalletService walletService, IShoppingCartService shoppingCartService, IInternalTourService internalTourService,IMapper mapper,IHttpClientService httpClient) : base(mapper)
        {

            _orderRepository = orderRepository;
            _shoppingCartService = shoppingCartService;
            _walletService = walletService;
            _internalTourService = internalTourService;
            _httpClientService = httpClient;
        }

        public Result CreateOrder(long userId, List<long> tourIds, string email)
        {
            var wallet = _walletService.Get(userId).Value;

            if (_shoppingCartService.GetCartPrice(userId) <= wallet.AdventureCoins)
            {
                try
                {
                    double coinsToRemove = 0;
                    foreach (var id in tourIds)
                    {
                        var tour = _internalTourService.GetById(id).Value;
                        Order newOrder = new Order(userId, tour.Id, tour.Price);
                        coinsToRemove += tour.Price;
                        _orderRepository.CreateOrder(newOrder);
                    }

                    _walletService.RemoveAdventureCoins(userId, coinsToRemove);
                    _shoppingCartService.ClearCart(userId);
                    _httpClientService.SendEmail(email);
                    return Result.Ok();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return Result.Fail(FailureCode.Conflict).WithError("Problems with payment.");
                }

            }
            else
            {
                return Result.Fail(FailureCode.NotFound).WithError("Not enough money.");
            }
        }


        public Result<PagedResult<OrderDto>> GetByUser(int page, int pageSize, long userId)
        {
            try
            {
                var result = _orderRepository.GetByUserId(page, pageSize, userId);
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<int> GetOrderCount(long tourId)
        {
            return _orderRepository.GetOrderCount(tourId);
        }
    }
}
