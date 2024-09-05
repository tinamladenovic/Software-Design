using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class CompositeTourDto
    {
        public long Id { get; set; }
        public long TouristId { get; set; }
        public string Name { get; set; }
        public List<TourDto> Tours { get; set; }
        public Difficult Difficult { get; set; }
        public double Distance { get; set; }
        public List<EquipmentDto> Equipments { get; set; }
        public List<CheckpointDto> Checkpoints { get; set; }

    }
}
