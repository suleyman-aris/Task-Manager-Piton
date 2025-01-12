using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Abstract;
using TaskManager.Entities.Concrete;

namespace TaskManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController(IJobService _jobService) : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetJobsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        var getJobs = await _jobService.GetJobsByDateRangeAsync(startDate, endDate);
        return Ok(getJobs);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateJob([FromBody] Job task)
    {
        _jobService.AddAsync(task);
        return Ok();
    }
}