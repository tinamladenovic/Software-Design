using Newtonsoft.Json;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.Core.Domain.TourPackages;

namespace Explorer.Payments.Core.Domain.ShoppingCarts
{
    public class BundleItem : ValueObject
    {
        public long Id { get; private set; }
        public string BundleName {get; private set; }
        public double Price {get; private set; }
        public List<TourStatus> Tours { get; private set; }

        public BundleItem(){}

        [JsonConstructor]
        public BundleItem(long id, string bundleName, double price, List<TourStatus> tours)
        {
            Id = id;
            BundleName = bundleName;
            Price = price;
            Tours = tours;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return BundleName;
            yield return Price;
            yield return Tours;
        }
    }
}
