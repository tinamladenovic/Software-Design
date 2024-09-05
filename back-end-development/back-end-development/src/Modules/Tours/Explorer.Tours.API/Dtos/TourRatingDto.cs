using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class TourRatingDto
    {
        public int TourId { get; set; }
        public int TouristId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public DateTime Creted { get; set; }    
        public int CompletionPercentage { get; set; }
        public DateTime LastActivity { get;  set; }

    }
}
