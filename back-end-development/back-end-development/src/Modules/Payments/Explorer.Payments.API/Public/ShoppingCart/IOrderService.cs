namespace Explorer.Payments.API.Public.ShoppingCart
{
    using Explorer.BuildingBlocks.Core.UseCases;
    using Explorer.Payments.API.Dtos;
    using FluentResults;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IOrderService
    {
        Result CreateOrder(long userId, List<long> tourId,string email);
        Result<PagedResult<OrderDto>> GetByUser(int page, int pageSize, long userId);
        Result<int> GetOrderCount(long tourId);
    }
}
