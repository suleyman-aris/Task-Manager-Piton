using TaskManager.Core.DataAccess.EntityFramework.Abstract;
using TaskManager.Entities.Concrete;

namespace TaskManager.DataAccess.Abstract;

public interface IJobDAL : IEntityRepository<Job>
{
    public Task<List<Job>> GetJobsByDateRangeAsync(DateTime startDate, DateTime endDate);
}