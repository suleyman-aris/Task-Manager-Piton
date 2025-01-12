using System.Linq.Expressions;
using System.Security.Principal;
using TaskManager.Entities.Abstract;
namespace TaskManager.Core.DataAccess.EntityFramework.Abstract;

public interface IEntityRepository<T> where T : class, IEntity, new()
{
    T Get(Expression<Func<T, bool>> filter = null);
    List<T> GetList(Expression<Func<T, bool>> filter = null);

    void Add(T Entity);
    void Update(T Entity);
    void Delete(T Entity);
}