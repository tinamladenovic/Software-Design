using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IFollowersRepository
    {
        void Delete(long followedId, long followingId);
        List<Followers> GetAllForUser(long id);
        Followers GetById(long FollowedId, long FollowingId);
    }
}
