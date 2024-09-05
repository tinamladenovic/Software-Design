using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos
{
    public enum EncounterStatusDto
    {
        Active,
        Draft,
        Archieved
    }

    public enum EncounterTypeDto
    {
        Social,
        HiddenLocation,
        Misc
    }

    public class EncounterDto 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EncounterCoordinateDto Coordinates { get; set; }
        public int Xp { get; set; }
        public EncounterStatusDto Status { get; set; }
        public EncounterTypeDto Type { get; set; }
        public int Range { get; set; }
        public string? ImageUrl { get; set; }
        public string? MiscEncounterTask { get; set; }
        public int? SocialEncounterRequiredPeople { get; set; }
        public long? CheckpointId { get; set; }
        public bool? IsRequired { get; set; }
    }
}
