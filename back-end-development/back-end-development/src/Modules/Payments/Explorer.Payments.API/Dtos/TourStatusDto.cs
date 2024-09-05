

namespace Explorer.Payments.API.Dtos
{
    public enum Status
    {
        DRAFT,
        PUBLISHED,
        ARCHIVED
    }
    public class TourStatusDto
    {
        public long TourId { get; set; }
        public Status Status { get; set; }
        public string TourName { get; init; }
        public TourStatusDto() { }
        public TourStatusDto(long tourId, string tourName, int status)
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
        public TourStatusDto(long tourId, string tourName, Status status)
        {
            TourId = tourId;
            TourName = tourName;
            Status = status;
        }
    }
}
