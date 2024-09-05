namespace Explorer.Stakeholders.API.Dtos
{
    public class RequestToJoinClubDto
    {
        public int Id { get; set; }
        public long TouristId { get; set; }
        public long TouristClubId { get; set; }
        public ClubRequestEnum Status { get; set; }

        public enum ClubRequestEnum
        {
            OnHold,
            Accepted,
            Declined
        }
    }
}
