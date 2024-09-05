
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain;

public enum TourDifficult
{
    Easy,
    Medium,
    Hard
}

public enum TourTravelMethod
{
    Car,
    Bicycle,
    Boat,
    Walking
}

public enum Rating
{
    None,
    Low,
    Moderate,
    High
}


public class TourPreferences : Entity
{
    public long TouristId { get; init; }
    public TourDifficult TourDifficult { get; init; }
    public TourTravelMethod TourTravelMethod { get; init; }

    public Rating Rating { get; init; }
    public string Tags { get; init; }

    public TourPreferences() { }

    public TourPreferences(long touristId, TourDifficult tourDifficult, TourTravelMethod tourTravelMethod, Rating rating, string tags)
    {
        TouristId = touristId;
        TourDifficult = tourDifficult;
        TourTravelMethod = tourTravelMethod;
        Rating = rating;
        Tags = tags;
    }

}

