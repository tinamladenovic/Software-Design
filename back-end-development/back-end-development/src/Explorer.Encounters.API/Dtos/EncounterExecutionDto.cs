using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos
{
    public enum EncounterExecutionStatusDto 
    {
        Active,
        Completed,
        Abandoned
    }
    public class EncounterExecutionDto
    {
        public long Id { get; set; }
        public long EncounterId { get; set; }
        public long TouristId { get; set; }
        public EncounterExecutionStatusDto Status { get; set; }
        public DateTime LastActivity { get; set; }
        public DateTime? LocationEntryTimestamp { get; set; }
        public EncounterCoordinateDto LastPosition { get; set; }
    }
}
