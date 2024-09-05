using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public enum DestinationType { WC, Restaurant, Parking, Other }
    public class Destination : Entity
    {
        public long PersonId { get; init; }
        public double Longitude { get; init; }
        public double Latitude { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public string? ImageURL { get; init; }
        public DestinationType Type { get; init; }
        public PublicRequest? Request { get; private set; }

        public Destination(long id, long personId, double longitude, double latitude, string name, string? description, string? imageURL, DestinationType type, PublicRequest? request)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid Name.");
            if (longitude < -180 || longitude > 180) throw new ArgumentException("Invalid Longitude.");
            if (latitude < -90 || latitude > 90) throw new ArgumentException("Invalid Latitude.");
            Id = id;
            PersonId = personId;
            Longitude = longitude;
            Latitude = latitude;
            Name = name;
            Description = description;
            ImageURL = imageURL;
            Type = type;
            Request = request;
        }

        public Destination() { }

        public void Accept()
        {
            this.Request = new PublicRequest(CheckpointRequestStatus.Accepted, null);
        }

        public void Reject(string comment)
        {
            this.Request = new PublicRequest(CheckpointRequestStatus.Rejected, comment);
        }
    }
}
