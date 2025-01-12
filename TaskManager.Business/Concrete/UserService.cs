using TaskManager.Business.Abstract;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entities.Concrete;

namespace TaskManager.Business.Concrete;

public class UserService(IUserDAL _userDAL) : IUserService
{
    public void AddAsync(User user)
    {
        _userDAL.Add(user);
    }

    public async Task<User> GetUser(string userName, string password)
    {
        var IsUser =  _userDAL.Get(x => x.FullName == userName && x.Password == password);

        if (IsUser is null)
            return null;

        return IsUser;
    }
}
