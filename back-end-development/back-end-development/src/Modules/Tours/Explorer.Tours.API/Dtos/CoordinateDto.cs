using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos;

public class CoordinateDto
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public CoordinateDto() { }
    
}
