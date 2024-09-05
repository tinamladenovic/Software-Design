using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Payments.Core.Domain.ShoppingCarts
{
    public class ShoppingCart : Entity
    {
        public long UserId { get; init; }
        public List<OrderItem> Items { get; private set; }
        public string? TourCoupon { get; set; }
        public List<BundleItem> BundleItems { get; private set; }


        public ShoppingCart() { }

        public ShoppingCart(long userId, List<OrderItem> items, List<BundleItem> bundleItems)
        {
            UserId = userId;
            Items = items;
            BundleItems = bundleItems;
        }
        public void AddItemToCart(OrderItem item)
        {
            try
            {
                if (!Items.Any(i => i.TourId == item.TourId))
                    Items.Add(item);
            }
            catch(Exception ex)
            {
                return;
                //throw new InvalidOperationException("Item already exists in the shopping cart.");
            }
        }

        public void AddBundleToCart(BundleItem bundleItem)
        {
            if (BundleItems.Any(bi => bi.Id == bundleItem.Id))
            {
                throw new InvalidOperationException("Bundle already exists in the shopping cart.");
            }
            if (BundleItems.Count > 1 && Items.Count > 1)
            {
                foreach (var bundle in BundleItems)
                {
                    if (Items.Any(i => bundle.Tours.Any(item => item.TourId == i.TourId)))
                    {
                        throw new InvalidOperationException("Item already exists in the shopping cart.");
                    }
                }
            }
            BundleItems.Add(bundleItem);

        }
        public void RemoveItemFromCart(long tourId)
        {
            try
            {
                var itemToRemove = Items.Find(item => item.TourId == tourId);
                if (itemToRemove != null)
                {
                    Items.Remove(itemToRemove);
                }
                else
                {
                    throw new KeyNotFoundException("Item not found in the shopping cart.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public void RemoveBundleItemFromCart(long bundleId)
        {
            try
            {
                var itemToRemove = BundleItems.Find(item => item.Id == bundleId);
                if (itemToRemove != null)
                {
                    BundleItems.Remove(itemToRemove);
                }
                else
                {
                    throw new KeyNotFoundException("Item not found in the shopping cart.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void RefreshCart(List<OrderItem> items)
        {
            ClearCart();
            Items = items;
        }
        public void ClearCart()
        {
            Items.Clear();
            BundleItems.Clear();
        }
    }
}
