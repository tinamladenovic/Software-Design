using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.API.Dtos
{
    public class BundleItemDto
    {
        public long Id { get; set; }
        public string BundleName { get; set; }
        public double Price { get; set; }
        public List<TourStatusDto> Tours { get; set; }

        public BundleItemDto() { }
        public BundleItemDto(long id, string bundleName, double price, List<TourStatusDto> tours)
        {
            Id = id;
            BundleName = bundleName;
            Price = price;
            Tours = tours;
        }
    }
}
