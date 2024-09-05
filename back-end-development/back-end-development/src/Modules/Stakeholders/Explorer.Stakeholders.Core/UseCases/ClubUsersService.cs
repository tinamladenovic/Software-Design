using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class ClubUsersService : CrudService<ClubUsersDto, ClubUsers>, IClubUsersService
    {
        private readonly IClubUsersRepository ClubUsersRepository;
        public ClubUsersService(ICrudRepository<ClubUsers> crudRepository, IMapper mapper, IClubUsersRepository clubUsersRepository) : base(crudRepository, mapper) 
        {
            ClubUsersRepository = clubUsersRepository;
        }
        public Result Delete(long clubId, long userId)
        {
            try
            {
                ClubUsersRepository.Delete(clubId, userId);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.NotFound).WithError("");
            }
            
        }
    }
}
