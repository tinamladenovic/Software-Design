using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class TouristEquipment : Entity
    {
        public int TouristId { get; init; }
        public int EquipmentId { get; init;  }

        //public List<Tour> Tours { get; init; } = new List<Tour>();

        public TouristEquipment(int touristId, int equipmentId)
        { 
            TouristId = touristId;
            EquipmentId = equipmentId;

        }
    }
}
