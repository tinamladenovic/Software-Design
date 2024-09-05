using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TouristClubRepository : ITouristClubRepository
    {
        private readonly ToursContext _dbContextTours;
        public TouristClubRepository(ToursContext dbContextTours)
        {
            _dbContextTours = dbContextTours;
        }
        public List<TouristClub> GetOwnersClubs(int id) 
        {
            return _dbContextTours.TouristClubs.Where(club => club.OwnerId == id).ToList();
        }
    }
}
