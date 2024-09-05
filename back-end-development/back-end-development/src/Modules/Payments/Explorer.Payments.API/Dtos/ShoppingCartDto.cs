namespace Explorer.Payments.API.Dtos
{
    public class ShoppingCartDto
    {
        public long Id { get; set; }
        public long UserId { get; init; }
        public List<OrderItemDto> Items { get; set; }
        public List<BundleItemDto> BundleItems { get; set; }

        public ShoppingCartDto()
        {
        }

        public ShoppingCartDto(long userId, List<OrderItemDto> items, List<BundleItemDto> bundleItems)
        {
            UserId = userId;
            Items = items;
            BundleItems = bundleItems;
        }
        public ShoppingCartDto(long userId, List<OrderItemDto> items)
        {
            UserId = userId;
            Items = items;
        }
        public ShoppingCartDto(long id)
        {
            UserId = id;
        }
    }
}
