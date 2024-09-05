using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class TouristEquipmentDTO
    {
        public int Id { get; set; }
        public int TouristId { get; set; }
        public int EquipmentId { get; set; }
    }
}
