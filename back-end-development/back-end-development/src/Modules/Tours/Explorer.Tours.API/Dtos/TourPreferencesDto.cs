using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos;

public class TourPreferencesDto
{
    public long Id { get; set; }
    public long TouristId { get; set; }
    public string TourDifficult { get; set; }
    public string TourTravelMethod { get; set; }
    public string Rating { get; set; }
    public string Tags { get; set; }
}
