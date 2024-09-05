using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Internal;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class UserService : CrudService<UserDto, User>, IUserService, IInternalUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly IClubUsersRepository ClubUsersRepository;
        private readonly IClubRequestRepository ClubRequestsRepository;
        private readonly IFollowersRepository FollowersRepository;
        public UserService(ICrudRepository<User> crudRepository, IMapper mapper, IUserRepository userRepository, IClubUsersRepository clubUsersRepository, IClubRequestRepository clubRequestsRepository, IFollowersRepository followersRepository) : base(crudRepository, mapper)
        {
            UserRepository = userRepository;
            ClubUsersRepository = clubUsersRepository;
            ClubRequestsRepository = clubRequestsRepository;
            FollowersRepository = followersRepository;
        }
        public Result<List<UserDto>> GetClubMembers(long clubId, long logedInId)
        {
            List<User> users = new List<User>();
            users = UserRepository.GetUsersList(logedInId);
            List<ClubUsers> clubUsers = ClubUsersRepository.GetAllFromClub(clubId);
            List<User> usersFromClub = new List<User>();
            foreach (User user in users) 
            {
                foreach (ClubUsers clubUser in clubUsers) 
                {
                    if (user.Id == clubUser.TouristId) 
                    {
                        usersFromClub.Add(user);
                    }
                }
            }
            return MapToDto(usersFromClub);
        }
        public Result<List<UserDto>> GetNonClubMembers(long clubId, long logedInId)
        {
            List<User> users = new List<User>();
            users = UserRepository.GetUsersList(logedInId);
            List<ClubUsers> clubUsers = ClubUsersRepository.GetAllFromClub(clubId);
            List<ClubRequest> clubRequests = ClubRequestsRepository.GetAllFromClub(clubId);
            List<User> usersFromClub = new List<User>();
            foreach (User user in users)
            {
                int flag = 0;
                foreach (ClubUsers clubUser in clubUsers)
                {
                    if (user.Id == clubUser.TouristId)
                    {
                        flag = 1;
                    }
                }
                foreach (ClubRequest clubRequest in clubRequests) 
                {
                    if (user.Id == clubRequest.TouristId) 
                    {
                        flag = 1;
                    }
                }
                if (flag == 0) 
                {
                    usersFromClub.Add(user);
                }
            }
            return MapToDto(usersFromClub);
        }
        public Result<UserDto> GetUser(long userId)
        {
           return MapToDto(UserRepository.GetUser(userId));
        }

        public Result<List<UserDto>> GetNotFollowing(long logedInId) 
        {
            List<User> users = new List<User>();
            users = UserRepository.GetUsersForFollowing(logedInId);
            List<Followers> followers = FollowersRepository.GetAllForUser(logedInId);
            List<User> usersYouCanFollow = new List<User>();
            foreach (User user in users)
            {
                int flag = 0;
                foreach (Followers follower in followers)
                {
                    if (follower.FollowedId == user.Id)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    usersYouCanFollow.Add(user);
                }
            }
            return MapToDto(usersYouCanFollow);
        }
        public Result<List<UserDto>> GetAllExceptCurrent(long logedInId) 
        {
            List<User> users = new List<User>();
            users = UserRepository.GetAllExceptCurrent(logedInId);
            return MapToDto(users);
        }
        public Result<UserDto> GetById(long userId) 
        {
            User user = UserRepository.GetById(userId);
            return MapToDto(user);
        }

        
    }
}
