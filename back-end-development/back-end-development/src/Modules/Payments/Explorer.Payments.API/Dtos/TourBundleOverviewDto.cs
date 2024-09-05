using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class TourBundleOverviewDto
    {
        public long Id { get; set; }
        public string Name {get; set; }
        public List<String> ToursName {get; set; }
        public double Price { get; set; }
        public string? AuthorName {get; set; }

        public TourBundleOverviewDto(long id, string name, List<string> toursName, double price, string? authorName)
        {
            Id = id;
            Name = name;
            ToursName = toursName;
            Price = price;
            AuthorName = authorName;
        }
        public TourBundleOverviewDto(){}
    }
}
