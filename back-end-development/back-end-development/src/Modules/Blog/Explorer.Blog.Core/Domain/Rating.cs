using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Explorer.Blog.Core.Domain
{
    public enum RatingType
    {
        Upwote,
        Downvote,
    }
    public class Rating : ValueObject
    {
        public long UserId { get; set; }  
        public RatingType RatingType { get; set; }

        [JsonConstructor]
        public Rating(long userId, RatingType ratingType)
        {
            UserId = userId;
            RatingType = ratingType;
        }
            
        public void ChangeRating(Rating rating)
        {
            RatingType = rating.RatingType;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
            yield return RatingType;
        }
    }
}
