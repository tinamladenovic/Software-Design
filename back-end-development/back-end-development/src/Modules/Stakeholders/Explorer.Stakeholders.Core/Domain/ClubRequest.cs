using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Stakeholders.Core.Domain
{
    public class ClubRequest : Entity
    {
        public long TouristId { get; private set; }
        //public User Tourist { get; private set; }
        public long TouristClubId { get; private set; }
        public ClubRequestStatus Status { get; private set; }

        public ClubRequest()
        {

        }
        public ClubRequest(long touristId, long touristClubId, ClubRequestStatus status)
        {
            TouristId = touristId;
            TouristClubId = touristClubId;
            Status = status;
        }
        public enum ClubRequestStatus
        {
            Invited,
            Accepted,
            Declined,
            Kicked
        }
    }
}
