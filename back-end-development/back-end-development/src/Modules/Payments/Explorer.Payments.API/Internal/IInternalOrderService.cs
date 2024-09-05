using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public.ShoppingCart;
using FluentResults;

namespace Explorer.Payments.API.Internal
{
    public interface IInternalOrderService
    {
        Result CreateOrder(long userId, List<long> tourId, string email);
        Result<PagedResult<OrderDto>> GetByUser(int page, int pageSize, long userId);
        Result<int> GetOrderCount(long tourId);
    }
}
