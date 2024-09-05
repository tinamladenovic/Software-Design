namespace Explorer.Tours.API.Dtos;

public class CheckpointDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PictureURL { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int? TourId { get; set; }
    public PublicRequestDto PublicRequest { get; set; }

    public CheckpointDto()
    {

    }

    public CheckpointDto(long id, string name, string description, string pictureURL, decimal latitude,
        decimal longitude, int? tourId, PublicRequestDto publicRequest)
    {
        Id = id;
        Name = name;
        Description = description;
        PictureURL = pictureURL;
        Latitude = latitude;
        Longitude = longitude;
        TourId = tourId;
        PublicRequest = publicRequest;
    }
}