using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Execution
{
    public class TourExecutionUpdateDto
    {
        public CoordinateDto Coordinate { get; set; }
        public double CoveredDistance { get; set; }
    }
}
