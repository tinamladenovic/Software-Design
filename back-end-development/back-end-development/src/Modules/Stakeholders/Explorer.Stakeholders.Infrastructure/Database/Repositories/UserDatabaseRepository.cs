using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories;

public class UserDatabaseRepository : IUserRepository
{
    private readonly StakeholdersContext _dbContext;

    public UserDatabaseRepository(StakeholdersContext dbContext)
    {
        _dbContext = dbContext;
    }
    

    public PagedResult<User> GetPaged(int page, int pageSize)
    {
        var query = _dbContext.Users.Where(user => user.Role != UserRole.Administrator);
        var task = query.GetPaged(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public bool Exists(string username)
    {
        return _dbContext.Users.Any(user => user.Username == username);
    }

    public User? GetActiveByName(string username)
    {
        return _dbContext.Users.FirstOrDefault(user => user.Username == username && user.IsActive);
    }

    public User Create(User user)
    {
       _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        return user;
    }

    public long GetPersonId(long userId)
    {
        var person = _dbContext.People.FirstOrDefault(i => i.UserId == userId);
        if (person == null) throw new KeyNotFoundException("Not found.");
        return person.Id;
    }
    
    //UserDatabaseRepository
    public User GetUser(long id)
    {
        //Ovde mi _dbContext vrati user-e iz redovne explorer-v1 baze
        var user = _dbContext.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("Not found.");
        return user;
    }

    public User? BlockUser(long id)
    {
        var user = GetUser(id);
        if (user == null) throw new KeyNotFoundException("Not found.");
        user.IsActive = false;
        _dbContext.SaveChanges();
        return user;
    }
    
    public List<User> GetUsersList(long id) 
    {
        return _dbContext.Users.Where(user => user.Id != id && user.Role == UserRole.Tourist).ToList();
    }

    public List<User> GetUsersForFollowing(long id)
    {
        return _dbContext.Users.Where(user => user.Id != id && user.Role == UserRole.Tourist).ToList();
    }

    public PagedResult<User> Get(int page, int pageSize)
    {
        throw new NotImplementedException();
    }
    public List<User> GetAllExceptCurrent(long id)
    {
        return _dbContext.Users.Where(user => user.Id != id).ToList();
    }
    public User GetById(long id) 
    {
        User user = _dbContext.Users.FirstOrDefault(user => user.Id == id);
        if (user == null) throw new KeyNotFoundException("Not found.");
        return user;
    }

}