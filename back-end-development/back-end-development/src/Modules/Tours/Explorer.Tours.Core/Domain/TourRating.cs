using System;
using System.Collections.Generic;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain
{
    public class TourRating : Entity
    {
        public int TourId { get; init; }
        public int TouristId { get; init; }
        public int Rating { get; init; }
        public string Review { get; init; }
        public DateTime Created { get; init ; }
        public int CompletionPercentage { get; init; }
        public DateTime LastActivity { get; init; }

        public TourRating() { }

        public TourRating(int tourId, int touristId, int rating, string review, DateTime created, int completionPercentage, DateTime lastActivity)
        {
            TourId = tourId;
            TouristId = touristId;
            Rating = rating;
            Review = review;
            Created = created;
            CompletionPercentage = completionPercentage;
            LastActivity = lastActivity;

        }
    }
}

