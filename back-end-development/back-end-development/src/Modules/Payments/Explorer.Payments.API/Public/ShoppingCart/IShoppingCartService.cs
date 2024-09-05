using FluentResults;
using Explorer.Payments.API.Dtos;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;

namespace Explorer.Payments.API.Public.ShoppingCart
{
    public interface IShoppingCartService
    {
        Result<ShoppingCartDto> Get(long id);
        Result<ShoppingCartDto> Create(long id);
        Result<OrderItemDto> AddTour(OrderItemDto orderItem, int userId);
        Result<BundleItemDto> AddBundleTours(TourBundleDto bundle, int userId);
        Result<ShoppingCartDto> RemoveTour(long tourId, int cartId);
        Result<ShoppingCartDto> RemoveTourBundle(long bundleId, int cartId);
        Result<ShoppingCartDto> ClearCart(long userId);
        Result AddDiscount(string discountHash, long userId);
        double GetCartPrice(long userId);
    }
}
