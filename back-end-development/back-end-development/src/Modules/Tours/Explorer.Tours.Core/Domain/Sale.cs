using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class Sale : Entity
    {
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public int Percent { get; init; }
        public long AuthorId { get; init; }

        public Sale() { }

        public Sale(int percent, DateTime startDate, DateTime endDate,long authorId)
        {
            StartDate = startDate;
            EndDate = endDate;
            Percent = percent;
            AuthorId = authorId;
        }
    }
}
