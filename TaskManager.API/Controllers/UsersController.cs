using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Abstract;
using TaskManager.Entities.Concrete;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService _userService) : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            _userService.AddAsync(user);
            return Ok();
        }
    }
}
