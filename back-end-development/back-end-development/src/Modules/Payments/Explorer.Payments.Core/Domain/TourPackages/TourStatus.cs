using System.Text.Json.Serialization;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Payments.Core.Domain.TourPackages
{
    public class TourStatus : ValueObject
    {
        public long TourId { get; init; }
        public Status Status { get; private set; }
        public string TourName { get; init; }

        public TourStatus(){}
        public TourStatus(long tourId, string tourName)
        {
            TourId = tourId;
            Status = Status.DRAFT;
            TourName = tourName;
        }

        [JsonConstructor]
        public TourStatus(long tourId, string tourName, Status status)
        {
            TourId = tourId;
            TourName = tourName;
            Status = status;
        }
        public TourStatus(long tourId, int status, string tourName)
        {
            TourId = tourId;
            TourName = tourName;
            if (status == 0)
            {
                Status = Status.DRAFT;
            }
            else if (status == 1)
            {
                Status = Status.PUBLISHED;
            }
            else
            {
                Status = Status.ARCHIVED;
            }
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TourId;
            yield return Status;
            yield return TourName;
        }
    }
}
