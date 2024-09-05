using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Core.Domain
{
    public class TourReview : Entity
    {
        public string Comment { get; init; }
        public long TourId { get; init; }
        public int UserId { get; init; }
        public DateTime TimeOfComment { get; init; }
        public int Grade { get; init; }
        public DateTime TimeOfTour { get; init; }

        public Tour Tour { get; init; }


        public TourReview(string comment, long tourId, int userId, DateTime timeOfComment,int grade, DateTime timeOfTour)
        {
            Comment = comment;
            UserId = userId;
            TimeOfComment = timeOfComment;
            Grade = grade;
            TimeOfTour = timeOfTour;
            TourId = tourId;
        }

    }
}
