using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class FollowersRepository : IFollowersRepository
    {
        private readonly StakeholdersContext _dbContext;
        public FollowersRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(long followedId, long followingId)
        {

            var entity = _dbContext.Followers.FirstOrDefault(followers => followers.FollowedId == followedId && followers.FollowingId == followingId);
            if (entity == null) throw new Exception();
            _dbContext.Followers.Remove(entity);
            _dbContext.SaveChanges();
        }
        public List<Followers> GetAllForUser(long id)
        {
            return _dbContext.Followers.Where(follower => follower.FollowingId == id).ToList();
        }

        public Followers GetById(long FollowedId, long FollowingId)
        {
            Followers followers = _dbContext.Followers.FirstOrDefault(f => f.FollowedId == FollowedId && f.FollowingId == FollowingId);
            if (followers == null)
            {
                Followers fol = new Followers(0,0);
                return fol;                
            }
            return followers;
        }
    }
}
