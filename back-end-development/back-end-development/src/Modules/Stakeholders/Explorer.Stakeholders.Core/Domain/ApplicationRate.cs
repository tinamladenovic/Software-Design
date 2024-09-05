namespace Explorer.Stakeholders.Core.Domain
{
    using Explorer.BuildingBlocks.Core.Domain;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;

    public class ApplicationRate : Entity
    {
        public long PersonId { get; init; }
        public int Rate { get; init; }
        public string? Comment { get; init; }
        public DateTime CreationTime { get; init; }
        public Person Person { get; set; } = null!;

        public ApplicationRate(int rate, string? comment, DateTime creationTime)
        {
            if (rate>5 || rate<1) throw new ArgumentException("Invalid Rate.");
            this.Rate = rate;
            this.Comment = comment;
            this.CreationTime = creationTime;

        }
    }
}
