using TaskManager.Core.DataAccess.EntityFramework.Abstract;
using TaskManager.Entities.Concrete;

namespace TaskManager.DataAccess.Abstract;

public interface IUserDAL : IEntityRepository<User>
{
    public Task<User> GetUser(string userName, string password);
}