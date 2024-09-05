using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public enum Difficult
    {
        Easy,
        Medium,
        Hard
    }



    public enum Status
    {
        DRAFT, 
        PUBLISHED,
        ARCHIVED
    }
    public class TourDto
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Difficult Difficult { get; set; }
        //public TravelMethod TravelMethod { get; set; }
        public Status Status { get; set; }
        public double Price { get; set; }
        public string Tags { get; set; }

        //public int TravelTime { get; set; }

        public double Distance { get; set; }
        public DateTime PublishTime {  get; set; }
        public DateTime ArchiveTime { get; set; }

        public List<TravelTimeAndMethodDto> TravelTimeAndMethod { get; set; } = new List<TravelTimeAndMethodDto>();

        public List<EquipmentDto> TourEquipment { get; set; } = new List<EquipmentDto>();

        
    }
}
