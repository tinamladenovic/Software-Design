using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.API.Dtos
{
    public class OrderItemDto
    {
        public long TourId { get; set; }
        public string TourName { get; set; }
        public long Price { get; set; }

        public OrderItemDto()
        {

        }

        public OrderItemDto(long tourId, string tourName, long price)
        {
            TourId = tourId;
            TourName = tourName;
            Price = price;
        }
    }
}
