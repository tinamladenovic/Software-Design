using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class RequestToJoinClubService : CrudService<RequestToJoinClubDto, RequestToJoinClub>, IRequestToJoinClubService
    {
        //private readonly IRequestToJoinClubRepository _requestToJoinClubRepository;

        public RequestToJoinClubService(/*IRequestToJoinClubRepository requestToJoinClubRepository,*/ ICrudRepository<RequestToJoinClub> repository, IMapper mapper) : base(repository, mapper)
        {
           // _requestToJoinClubRepository = requestToJoinClubRepository;
        }

        //public RequestToJoinClub GetById(int id)
        //{
        //    return _requestToJoinClubRepository.GetById(id);
        //}
    }
}
