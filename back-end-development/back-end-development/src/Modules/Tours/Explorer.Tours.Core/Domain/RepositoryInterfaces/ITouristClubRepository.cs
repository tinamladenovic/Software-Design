using Explorer.Tours.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces;

public interface ITouristClubRepository
{
    //bool Exists(int id);
    //TouristClub? GetTouristClub(int id);
    List<TouristClub> GetOwnersClubs(int id);
}
