using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Encounters.Core.Domain;
using Shouldly;

namespace Explorer.Encounters.Tests.UnitTests
{
    public class HiddenLocEncounterExecutionTests
    {
        [Fact]
        public void Clears_location_entry_timestamp()
        {
            // Arrange
            var encounterExecution = getEncounterExecution();
            var encounter = getEncounter();

            // Act
            encounterExecution.CheckIfCompletedHiddenLocation(encounter, new Coordinate(40.6776M, -75.4336M));

            // Assert
            encounterExecution.LocationEntryTimestamp.ShouldBeNull();
        }

        private Encounter getEncounter()
        {
            return new Encounter()
            {
                Name = "Test",
                Description = "Test",
                Coordinates = new Coordinate(40.6789M, -75.4321M),
                Xp = 10,
                Status = EncounterStatus.Active,
                Type = EncounterType.HiddenLocation,
                Range = 5
            };
        }

        private EncounterExecution getEncounterExecution()
        {
            return new EncounterExecution(1, 1, EncounterExecutionStatus.Active, DateTime.UtcNow, new Coordinate(40.678923M, -75.432146M));
        }   
    }
}
