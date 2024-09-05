using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Payments.Core.Domain.ShoppingCarts;

namespace Explorer.Payments.Core.Domain.RepositoryInterfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetById(long id);
        ShoppingCart GetByUserId(long id);
        ShoppingCart Create(ShoppingCart shoppingCart);
        void AddToCartUpdate(ShoppingCart cart);
        ShoppingCart RemoveFromCartUpdate(ShoppingCart cart);
        void AddDiscound(long id, string couponHash);

        void Update(ShoppingCart cart);
    }
}
