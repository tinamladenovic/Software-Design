using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Payments.Core.Domain
{
    public class PaymentRecord : Entity
    {
        public long TouristId { get; private set; }
        public long BundleId { get; private set; }
        public double Amount { get; private set; }
        public DateTime Time { get; private set; }
        public PaymentRecord() { }
        public PaymentRecord(long touristId, long bundleId, double amount)
        {
            TouristId = touristId;
            BundleId = bundleId;
            Amount = amount;
            Time = DateTime.Now.ToUniversalTime();
        }

    }
}
