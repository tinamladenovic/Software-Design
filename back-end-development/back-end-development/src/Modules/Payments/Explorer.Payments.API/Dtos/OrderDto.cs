using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Tours.API.Dtos.Execution;

namespace Explorer.Payments.API.Dtos
{
    public class OrderDto
    {
        public long UserId { get; init; }
        public long TourId { get; init; }

        public double Price { get; init; }
        public DateTime PaymentTime { get; init; }


        public OrderDto() { }

        public OrderDto(long userId, long tourId, double price, DateTime time)
        {
            UserId = userId;
            TourId = tourId;
            Price = price;
            PaymentTime = time;

        }




    }
}
