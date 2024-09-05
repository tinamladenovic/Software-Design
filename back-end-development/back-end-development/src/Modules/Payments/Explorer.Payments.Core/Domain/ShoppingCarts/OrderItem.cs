using Explorer.BuildingBlocks.Core.Domain;
using Newtonsoft.Json;

namespace Explorer.Payments.Core.Domain.ShoppingCarts
{
    public class OrderItem : ValueObject
    {
        public long TourId { get; }
        public string TourName { get; }
        public double Price { get; }


        //public Tour Tour {  get; }

        //[JsonConstructor]
        public OrderItem() { }



        [JsonConstructor]
        public OrderItem(long tourId, string tourName, double price)
        {
            TourId = tourId;
            TourName = tourName;
            Price = price;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TourId;
            yield return TourName;
            yield return Price;
        }
    }
}
