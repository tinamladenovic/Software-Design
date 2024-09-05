using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public class FollowersDto
    {
        public int Id { get; set; }
        public long FollowedId { get; set; }
        public long FollowingId { get; set; }
    }
}
