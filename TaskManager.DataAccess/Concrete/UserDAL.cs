using TaskManager.Core.DataAccess.EntityFramework.Concrete;
using TaskManager.DataAccess.Abstract;
using TaskManager.DataAccess.AppDbContext;
using TaskManager.Entities.Concrete;

namespace TaskManager.DataAccess.Concrete;

public class UserDAL : EfEntityRepositoryBase<User, Context>, IUserDAL
{
    public async Task<User> GetUser(string userName, string password)
    {
        using (var context = new Context())
        {
            var IsUser = context.Users.FirstOrDefault(x => x.FullName == userName && x.Password == password);

            if (IsUser == null)
                return null;

            return IsUser;
        }
    }
}
