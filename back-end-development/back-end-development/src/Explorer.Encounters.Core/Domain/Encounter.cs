using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Encounters.Core.Domain
{
    public enum EncounterStatus
    {
        Active,
        Draft,
        Archieved
    }

    public enum EncounterType
    {
        Social,
        HiddenLocation,
        Misc
    }

    public class Encounter : Entity
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public Coordinate Coordinates { get; init; }
        public int Xp { get; init; }
        public EncounterStatus Status { get; init; }
        public EncounterType Type { get; init; }
        public int Range { get; init; }
        public string? ImageUrl { get; init; }
        public string? MiscEncounterTask { get; init; }
        public int? SocialEncounterRequiredPeople { get; init; }

        //If exist - encounter is only available at checkpoint
        public long? CheckpointId { get; init; }
        public bool? IsRequired { get; set; }

        public Encounter(string name, string description, Coordinate coordinates, int xp, EncounterStatus status, EncounterType type, int range, string? imageUrl, string? miscEncounterTask, int? socialEncounterRequiredPeople, long? checkpointId, bool? isRequired)
        {
            Name = name;
            Description = description;
            Coordinates = coordinates;
            Xp = xp;
            Status = status;
            Type = type;
            Range = range;
            ImageUrl = imageUrl;
            MiscEncounterTask = miscEncounterTask;
            SocialEncounterRequiredPeople = socialEncounterRequiredPeople;
            CheckpointId = checkpointId;
            IsRequired = isRequired;
        }

        public Encounter()
        {
        }

        public bool IsWithinRange(Coordinate coordinate)
        {
            return Coordinates.DistanceTo(coordinate) <= Range;
        }

        public bool IsWithinHiddenLocationRange(Coordinate coordinate)
        {
            return Coordinates.DistanceTo(coordinate) <= 5;
        }
    }
}
