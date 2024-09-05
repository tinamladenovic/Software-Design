using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Leaderboards
{
    public class TouristCompletedToursDto
    {
        public long TouristId { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CompletedTours { get; set; }

        public TouristCompletedToursDto(long touristId, int rank, string name, string surname, int completedTours)
        {
            TouristId = touristId;
            Rank = rank;
            Name = name;
            Surname = surname;
            CompletedTours = completedTours;
        }
    }
}
