using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Stakeholders.Core.Domain
{
    public class RequestToJoinClub : Entity
    {
        public long TouristId { get; private set; }
        public long TouristClubId { get; private set; } 
        public ClubRequestEnum Status { get; private set; }

        public RequestToJoinClub()
        {
            
        }
        public RequestToJoinClub(long touristId, long touristClubId, ClubRequestEnum status)
        {
            TouristId = touristId;
            TouristClubId = touristClubId;
            Status = status; 
        }


        public enum ClubRequestEnum
        {
            OnHold,
            Accepted,
            Declined
        }

    }
}
