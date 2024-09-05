using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public  class TourReviewDto
    {
        public int TourId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public DateTime TimeOfComment { get; set; }
        public int Grade { get; set; }
        public DateTime TimeOfTour { get; set; }


    }
}
