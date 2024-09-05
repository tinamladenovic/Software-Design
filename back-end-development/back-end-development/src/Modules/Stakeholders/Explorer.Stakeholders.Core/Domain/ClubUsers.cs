using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class ClubUsers : Entity
    {
        public long TouristId { get; private set; }
        public long TouristClubId { get; private set; }

        public ClubUsers()
        {

        }
        public ClubUsers(long touristId, long touristClubId)
        {
            TouristId = touristId;
            TouristClubId = touristClubId;
        }
    }
}
