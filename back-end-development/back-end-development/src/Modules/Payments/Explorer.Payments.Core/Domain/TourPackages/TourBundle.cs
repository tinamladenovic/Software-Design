using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Payments.Core.Domain.TourPackages
{
    public enum Status
    {
        DRAFT,
        PUBLISHED,
        ARCHIVED
    }
    public class TourBundle : Entity
    {
        public long AuthorId { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public Status Status { get; private set; }
        public List<TourStatus> Tours {get; private set; }
        public TourBundle() { }
        public TourBundle(long authorId, string name, double price,List<TourStatus> tours, Status status = Status.DRAFT)
        {
            AuthorId = authorId;
            Name = name;
            Price = price;
            Status = status;
            Tours = tours;
        }

        public void AddTour(TourStatus tour)
        {
            Tours.Add(tour);
        }

        public void ArchivePackage()
        {
            if (Status == Status.PUBLISHED)
            {
                Status = Status.ARCHIVED;
            }
        }

        public void PublishPackage()
        {
            if (Tours.Count(t => t.Status == Status.PUBLISHED) >= 2)
            {
                Status = Status.PUBLISHED;
            }
            else
            {
                throw new InvalidOperationException(
                    "Bundle cannot be published because there is no enough tours with 'published' status.");
            }
        }

        public void ChangePrice(double newPrice)
        {
            this.Price = newPrice;
        }
    }
}
