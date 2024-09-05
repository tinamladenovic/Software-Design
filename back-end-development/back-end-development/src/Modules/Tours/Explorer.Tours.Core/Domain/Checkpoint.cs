using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Core.Domain;

public class Checkpoint : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string PictureURL { get; private set; }
    public Coordinate Coordinates { get; private set; }
    public long TourId { get; private set; }
    public PublicRequest? Request { get; private set; }
    public Tour Tour { get; init; }

    //TO DO: dodati validacije

    private Checkpoint()
    {

    }

    public Checkpoint(string name, string description, string pictureURL, Coordinate coordinates, long tourId)
    {
        Name = name;
        Description = description;
        PictureURL = pictureURL;
        Coordinates = coordinates;
        TourId = tourId;
    }

    public Checkpoint(long id, string name, string description, string pictureURL, Coordinate coordinates, long tourId)
    {
        Id = id;
        Name = name;
        Description = description;
        PictureURL = pictureURL;
        Coordinates = coordinates;
        TourId = tourId;
    }

    public bool IsWithin(decimal latitude, decimal longitutude, double range)
    {
        return Coordinates.IsCloseTo(new Coordinate(latitude, longitutude), range);
    }
    
    public void Accept()
    {
        Request = new PublicRequest(CheckpointRequestStatus.Accepted, comment: null);
    }
    
    public void Reject(string comment)
    {
        Request = new PublicRequest(CheckpointRequestStatus.Rejected, comment);
    }

}
