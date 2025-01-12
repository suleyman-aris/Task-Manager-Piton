using Microsoft.EntityFrameworkCore;
using TaskManager.Core.DataAccess.EntityFramework.Concrete;
using TaskManager.DataAccess.Abstract;
using TaskManager.DataAccess.AppDbContext;
using TaskManager.Entities.Concrete;

namespace TaskManager.DataAccess.Concrete;

public class JobDAL : EfEntityRepositoryBase<Job, Context>, IJobDAL
{
    public async Task<List<Job>> GetJobsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        using(var context = new Context())
        {
            var query =
                from job in context.Jobs
                where job.StartDate >= startDate && job.EndDate <= endDate
                select job;

            return await Task.FromResult(query.ToList());
        }
    }
}
