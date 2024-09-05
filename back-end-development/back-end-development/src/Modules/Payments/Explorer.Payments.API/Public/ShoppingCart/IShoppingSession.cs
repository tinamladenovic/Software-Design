using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.API.Public.ShoppingCart
{
    public interface IShoppingSession
    {
        void AddTourToShoppingCartEvent(long id);
        void AddCouponToShoppingCartEvent(long id);
        void AddTourBundleToShoppingCartEvent(long id);
        void RemoveTourShoppingCartEvent(long id);
        void RemoveTourBundleShoppingCartEvent(long id);
        void CloseShoppingEvent(long id);
    }
}
