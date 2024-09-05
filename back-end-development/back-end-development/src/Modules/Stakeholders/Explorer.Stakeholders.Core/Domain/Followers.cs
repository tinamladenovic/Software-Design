using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class Followers : Entity
    {
        public long FollowedId { get; private set; }
        public long FollowingId { get; private set; }

        public Followers()
        {

        }
        public Followers(long followedId, long followingId)
        {
            FollowedId = followedId;
            FollowingId = followingId;
        }
    }
}
