using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain.RepositoryInterfaces
{
    public interface IOrderRepository
    {
        Result<PagedResult<Order>> GetByUserId(int page, int pageSize,long userId);
        void CreateOrder(Order order);
        int GetOrderCount(long tourId);
    }   
}
