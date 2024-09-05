using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Internal;
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
    public class FollowersService : CrudService<FollowersDto, Followers>, IFollowersService, IInternalFollowersService
    {
        private readonly IFollowersRepository FollowersRepository;
        public FollowersService(ICrudRepository<Followers> crudRepository, IMapper mapper, IFollowersRepository followersRepository) : base(crudRepository, mapper)
        {
            FollowersRepository = followersRepository;
        }
        public Result Delete(long followedId, long followingId)
        {
            try
            {
                FollowersRepository.Delete(followedId, followingId);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.NotFound).WithError("");
            }

        }

        public List<long> GetFollowingForUser(long userId)
        {
            List<long> followedIds = new List<long>();
            List<Followers> followed = new List<Followers>();
            followed = FollowersRepository.GetAllForUser(userId);
            foreach (Followers f in followed) 
            {
                followedIds.Add(f.FollowedId);
            }
            return followedIds;
        }

        public List<long> GetUsersFollowedIds(long userId)
        {
            List<long> followedIds = new List<long>();
            List<Followers> followed = new List<Followers>();
            followed = FollowersRepository.GetAllForUser(userId);
            foreach (Followers f in followed)
            {
                followedIds.Add(f.FollowedId);
            }
            return followedIds;
        }

        public Result<FollowersDto> GetById(long followedId,long followingId)
        {
            Followers followers = FollowersRepository.GetById(followedId,followingId);
            return MapToDto(followers);
        }
    }
}
