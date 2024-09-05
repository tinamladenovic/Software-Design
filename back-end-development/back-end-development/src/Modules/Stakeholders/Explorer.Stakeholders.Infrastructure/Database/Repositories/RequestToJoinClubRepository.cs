using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class RequestToJoinClubRepository : IRequestToJoinClubRepository
    {

        private readonly StakeholdersContext _dbContext;
        public RequestToJoinClubRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public RequestToJoinClub GetById(int id)
        {
            return _dbContext.RequestsToJoinClub.FirstOrDefault(request => request.Id == id);
        }
    }
}
