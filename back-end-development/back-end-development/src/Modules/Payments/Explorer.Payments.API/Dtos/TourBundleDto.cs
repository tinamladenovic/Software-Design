using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Payments.API.Dtos;

namespace Explorer.Payments.API.Dtos
{
    public enum BundleStatus
    {
        DRAFT,
        PUBLISHED,
        ARCHIVED
    }
    public class TourBundleDto
    {
        public long Id {get; set; }
        public long AuthorId {get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public BundleStatus Status { get; set; }
        public List<TourStatusDto> Tours { get; set; }

        public TourBundleDto(){ }
        public TourBundleDto(string name, double price, List<TourStatusDto> tours)
        {
            Name = name; 
            Price = price;
            Status = BundleStatus.DRAFT;
            Tours = tours;
        }
    }
}
