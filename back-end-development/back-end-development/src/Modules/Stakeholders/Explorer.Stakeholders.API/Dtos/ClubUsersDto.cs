using Explorer.Stakeholders.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public class ClubUsersDto
    {
        public int Id { get; set; }
        public long TouristId { get; set; }
        public long TouristClubId { get; set; }
    }
}
