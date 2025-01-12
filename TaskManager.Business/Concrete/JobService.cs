using TaskManager.Business.Abstract;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entities.Concrete;
using TaskManager.Entities.Enum;

namespace TaskManager.Business.Concrete;

public class JobService(IJobDAL _jobDAL) : IJobService
{
    public void AddAsync(Job task)
    {
        if (task.Status != JobStatus.ToDo)
        {
            task.Status = JobStatus.ToDo;
        }
        _jobDAL.Add(task);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Job>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Job> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Job>> GetJobsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return _jobDAL.GetJobsByDateRangeAsync(startDate, endDate);
    }

    public Task UpdateAsync(Job task)
    {
        throw new NotImplementedException();
    }
}
