using TaskManager.Entities.Concrete;

namespace TaskManager.Business.Abstract;

public interface IUserService
{
    void AddAsync(User user);
    Task<User> GetUser(string userName, string password);
}
