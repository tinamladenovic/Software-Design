using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Leaderboards
{
    public class TouristCoveredDistanceDto
    {
        public long TouristId { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double CoveredDistance { get; set; }

        public TouristCoveredDistanceDto(long touristId, int rank, string name, string surname, double coveredDistance)
        {
            TouristId = touristId;
            Rank = rank;
            Name = name;
            Surname = surname;
            CoveredDistance = coveredDistance;
        }
    }
}
