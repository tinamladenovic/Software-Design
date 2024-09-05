using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public enum TravelMethod
    {
        CAR,
        BICYCLE,
        WALKING
    }
    public class TravelTimeAndMethodDto
    {

        public int TravelTime { get; set; }
        public TravelMethod TravelMethod { get; set; }
        public TravelTimeAndMethodDto(TravelMethod travelMethod, int travelTime)
        {
            TravelMethod = travelMethod;
            TravelTime = travelTime;
        }
    }
}
