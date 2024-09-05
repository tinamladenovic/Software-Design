using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Club;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Club;

public class TouristClubService : CrudService<TouristClubDto, TouristClub>, ITouristClubService
{
    private readonly ITouristClubRepository TouristClubRepository;
    public TouristClubService(ICrudRepository<TouristClub> crudRepository, IMapper mapper,ITouristClubRepository touristClubRepository) : base(crudRepository, mapper)
    {
        TouristClubRepository = touristClubRepository;
    }
    public Result<List<TouristClubDto>> GetClubsForOwner(int id) 
    {
        List<TouristClub> clubs = new List<TouristClub>();
        clubs = TouristClubRepository.GetOwnersClubs(id);
        return MapToDto(clubs);
    }
}
