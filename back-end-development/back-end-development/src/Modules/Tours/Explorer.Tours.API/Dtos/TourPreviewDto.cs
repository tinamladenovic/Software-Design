using System.ComponentModel.DataAnnotations.Schema;

namespace Explorer.Tours.API.Dtos
{
    using System.Collections.Generic;

    public class TourPreviewDto
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Difficult Difficult { get; set; }

        public double Price { get; set; }

        public double Distance { get; set; }
        [NotMapped]
        public bool IsFavorite { get; set; }
        public List<TourReviewDto> TourReviews { get; set; }

        public List<CheckpointDto> Checkpoints { get; set; }

        public bool Equals(TourPreviewDto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((TourPreviewDto)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}
