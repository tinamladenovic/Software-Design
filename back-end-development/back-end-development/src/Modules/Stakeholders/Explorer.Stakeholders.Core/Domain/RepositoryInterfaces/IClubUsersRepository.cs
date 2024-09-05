using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IClubUsersRepository
    {
        void Delete(long clubId, long userId);
        List<ClubUsers> GetAllFromClub(long clubId);
    }
}
