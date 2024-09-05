using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Core.Domain
{
    public enum EncounterExecutionStatus
    {
        Active,
        Completed,
        Abandoned
    }
    public class EncounterExecution : Entity
    {
        public long EncounterId { get; init; }
        public long TouristId { get; init; }
        public EncounterExecutionStatus Status { get; private set; }
        public DateTime LastActivity { get; private set; }
        public DateTime? LocationEntryTimestamp { get; private set; }
        public Coordinate LastPosition { get; private set; }

        public EncounterExecution(Encounter encounter, long touristId, EncounterExecutionStatus status, Coordinate currentPosition)
        {
            ValidateInRange(encounter, currentPosition);
            EncounterId = encounter.Id;
            TouristId = touristId;
            Status = status;
            LastActivity = DateTime.UtcNow;
            LastPosition = currentPosition;
        }

        // Koristim samo za unit testove
        public EncounterExecution(long encounterId, long touristId, EncounterExecutionStatus status, DateTime? locationEntryTimestamp, Coordinate lastPosition)
        {
            EncounterId = encounterId;
            TouristId = touristId;
            Status = status;
            LastActivity = DateTime.UtcNow;
            LocationEntryTimestamp = locationEntryTimestamp;
            LastPosition = lastPosition;
        }

        public EncounterExecution() { }

        private void ValidateInRange(Encounter encounter, Coordinate currentPosition)
        {
            if (!encounter.IsWithinRange(currentPosition))
                throw new InvalidOperationException("You need to get in encounter range!");
        }

        public void Abandon()
        {
            ValidateIsActive();
            Status = EncounterExecutionStatus.Abandoned;
            UpdateLastActivityInformation();
        }

        public void CheckIfCompletedHiddenLocation(Encounter encounter, Coordinate currentPosition)
        {
            ValidateIsActive();
            UpdateLastActivityInformation(currentPosition);

            if (encounter.IsWithinHiddenLocationRange(currentPosition) && !LocationEntryTimestamp.HasValue)
            {
                LocationEntryTimestamp = DateTime.UtcNow;
            }
            else if (!encounter.IsWithinHiddenLocationRange(currentPosition) && LocationEntryTimestamp.HasValue)
            {
                LocationEntryTimestamp = null;
            }
            else if (encounter.IsWithinHiddenLocationRange(currentPosition) && LocationEntryTimestamp.HasValue && HasCompletedLocationEntryDelay())
            {
                Complete();
            }
        }

        private bool HasCompletedLocationEntryDelay()
        {
            return LastActivity - LocationEntryTimestamp.Value >= TimeSpan.FromSeconds(30);
        }

        public void Complete(Coordinate currentPosition = null)
        {
            ValidateIsActive();
            Status = EncounterExecutionStatus.Completed;
            UpdateLastActivityInformation(currentPosition);
        }

        public void UpdateLastActivityInformation(Coordinate currentPosition = null)
        {
            LastActivity = DateTime.UtcNow;
            if (currentPosition != null)
                LastPosition = currentPosition;
        }

        private void ValidateIsActive()
        {
            if (Status != EncounterExecutionStatus.Active)
                throw new InvalidOperationException("Encounter execution is not active");
        }
    }
}
