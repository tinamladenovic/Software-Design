namespace Explorer.Tours.API.Dtos;

public class TourSearchDto
{
    public double Range { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public TourSearchDto()
    {

    }

    public TourSearchDto(decimal latitude, decimal longitude, double range)
    {
        Latitude = latitude;
        Longitude = longitude;
        Range = range;
    }
}
