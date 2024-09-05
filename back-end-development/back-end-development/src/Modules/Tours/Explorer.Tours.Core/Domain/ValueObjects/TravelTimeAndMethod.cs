using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.ValueObjects
{

    public enum TravelMethod
    {
        CAR,
        BICYCLE,
        WALKING
    }

    public class TravelTimeAndMethod
    {
        public int TravelTime { get; set; }
        public TravelMethod TravelMethod { get; set; }
        public TravelTimeAndMethod(TravelMethod travelMethod, int travelTime)
        {
            TravelMethod = travelMethod;
            TravelTime = travelTime;
        }

    }


}
