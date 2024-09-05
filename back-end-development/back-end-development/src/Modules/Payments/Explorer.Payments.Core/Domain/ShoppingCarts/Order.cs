using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Payments.Core.Domain
{
    public class Order : Entity
    {

        public long UserId { get; init; }
        public long TourId { get; init; }

        public double Price {  get; init; }
        public DateTime PaymentTime {  get; init; }



        //public Tour Tour { get; set; }

        public Order() { }
        public Order(long userId, long tourid, double price)
        {
            UserId = userId;
            TourId = tourid;
            Price = price;
            PaymentTime = DateTime.UtcNow;
            
        }



    }
}
