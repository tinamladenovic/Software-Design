using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class DestinationDto
    {
        public long? Id { get; set; }
        public long PersonId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public string Type { get; set; }
        public PublicRequestDto? PublicRequest { get; set; }

    }
}
