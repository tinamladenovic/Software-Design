using Explorer.Payments.Core.Domain.ShoppingSessionEventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain.RepositoryInterfaces
{
    public interface IShoppingSessionRepository
    {
        ShoppingSessionEvent Create(ShoppingSessionEvent shoppingSessionEvent);
        void UpdateShoppingSessionEvent(ShoppingSessionEvent shoppingEvent);
        ShoppingSessionEvent GetByAggregateId(long aggregateId);
    }
}
