using TaskManager.Entities.Concrete;

namespace TaskManager.Business.Abstract;

public interface IJobService
{
    Task<Job> GetByIdAsync(int id);
    Task<IEnumerable<Job>> GetAllAsync();
    void AddAsync(Job task);
    Task UpdateAsync(Job task);
    Task DeleteAsync(int id);
    public Task<List<Job>> GetJobsByDateRangeAsync(DateTime startDate, DateTime endDate);
}
