using Explorer.BuildingBlocks.Core.UseCases;

namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;

public interface IUserRepository
{
    bool Exists(string username);
    PagedResult<User> Get(int page, int pageSize);
    PagedResult<User> GetPaged(int page, int pageSize);
    User? GetActiveByName(string username);
    User Create(User user);
    long GetPersonId(long userId);
    User? BlockUser(long userId);
    List<User> GetUsersList(long id);
    User GetUser(long id);
    List<User> GetUsersForFollowing(long id);
    List<User> GetAllExceptCurrent(long id);
    User GetById(long id);
}