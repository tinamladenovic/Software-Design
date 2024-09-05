using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Explorer.Stakeholders.Core.Domain.ClubRequest;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class ClubRequestRepository : IClubRequestRepository
    {
        private readonly StakeholdersContext _dbContext;
        public ClubRequestRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ClubRequest> GetAllFromClub(long clubId)
        {
            return _dbContext.ClubRequests.Where(clubRequest => clubRequest.TouristClubId == clubId && clubRequest.Status==ClubRequestStatus.Invited).ToList();
        }
    }
}
