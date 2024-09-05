using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class ClubUsersRepository : IClubUsersRepository
    {
        private readonly StakeholdersContext _dbContext;
        public ClubUsersRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(long clubId, long userId)
        {

            var entity = _dbContext.ClubUsers.FirstOrDefault(cu => cu.TouristClubId == clubId && cu.TouristId == userId);
            if (entity == null) throw new Exception();
            _dbContext.ClubUsers.Remove(entity);
            _dbContext.SaveChanges();
        }
        public List<ClubUsers> GetAllFromClub(long clubId) 
        {
            return _dbContext.ClubUsers.Where(clubUser => clubUser.TouristClubId == clubId).ToList();
        }
    }
}
