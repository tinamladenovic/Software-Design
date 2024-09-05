using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Tours.Core.Domain.ValueObjects;

namespace Explorer.Tours.Core.Domain.Tours
{
    public enum Difficult
    {
        EASY,
        MEDIUM,
        HARD
    }

    public enum Status
    {
        DRAFT,
        PUBLISHED,
        ARCHIVED
    }
    public class Tour : Entity
    {
        public long AuthorId { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public Difficult Difficult { get; init; }
        public List<TravelTimeAndMethod> TravelTimeAndMethod { get; set; } = new List<TravelTimeAndMethod>();
        public Status Status { get; set; }
        public double Price { get; init; }
        public string Tags { get; init; } //Profesor je rekao da za sada ostavim kao string i na frontu prikazujem kao splitovan string
        public virtual List<Equipment> TourEquipment { get; init; }
        public virtual List<Checkpoint> Checkpoints { get; init; }

        public double Distance { get; init; }

        public DateTime? PublishTime { get;set; }
//        public ICollection<Order> Orders { get; set; }

        public IEnumerable<TourReview> TourReviews { get; init; }

        public DateTime? ArchiveTime { get; set; }
        
        public List<FavouriteTour> FavouriteTours { get; set; }

        public List<CompositeTour> CompositeTour { get; init; } = new List<CompositeTour>();

        public Tour(long authorId, string name, string description, Difficult difficult, Status status, double price, string tags, List<TravelTimeAndMethod> travelTimeAndMethod
, double distance            )
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            AuthorId = authorId;
            Name = name;
            Description = description;
            Difficult = difficult;
            Status = status;
            Price = price;
            Tags = tags;
            TourEquipment = new List<Equipment>();
            Checkpoints = new List<Checkpoint>();
            TravelTimeAndMethod = travelTimeAndMethod;
            Validate();
            Distance = distance;
//            Orders = new List<Order>();
        }

        public void AddCheckpoint(Checkpoint checkpointToAdd)
        {
            Checkpoints.Add(checkpointToAdd);
            //TO DO: validacija koordinata
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new InvalidOperationException("Name cannot be null");
            }
            if (string.IsNullOrEmpty(Description))
            {
                throw new InvalidOperationException("Author Id has to be greater than zero");
            }
            if (Difficult < 0)
            {
                throw new InvalidOperationException("Tour has to have assigned difficulty");
            }

            if (string.IsNullOrEmpty(Tags))
            {
                throw new InvalidOperationException("Tour has to contain tags");
            }
            //if(!(TravelTimeAndMethod.Count >= 1))
            //{
            //    throw new InvalidOperationException("Travel time and method has to be defined at least once");
            //}

        }
        public Tour() {
            TravelTimeAndMethod = new List<TravelTimeAndMethod>();
            Checkpoints = new List<Checkpoint> ();
            TourEquipment = new List<Equipment>();
        }
        
        public bool IsFavourite(int touristId)
        {
            return FavouriteTours.Any(x => x.TouristId == touristId);
        }

    }

}
