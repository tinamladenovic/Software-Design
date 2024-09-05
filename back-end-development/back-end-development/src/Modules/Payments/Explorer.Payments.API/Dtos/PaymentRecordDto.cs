using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.API.Dtos
{
    public class PaymentRecordDto
    {
        public long Id { get; set; } 
        public long TouristId { get; set; } 
        public long BundleId { get; set; } 
        public double Amount { get; set; } 
        public DateTime Time { get; set; } 
        public PaymentRecordDto() { }
        public PaymentRecordDto(long id, long touristId, long bundleId, double amount, DateTime time)
        {
            Id = id;
            TouristId = touristId;
            BundleId = bundleId;
            Amount = amount;
            Time = time;
        }
    }
}
