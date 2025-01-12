using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Abstract;

namespace TaskManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IJwtService _jwtService) : ControllerBase
{
    [HttpPost("token")]
    public IActionResult GenerateToken(string userName, string password)
    {
        var token = _jwtService.GenerateToken(userName, password);

        if (!string.IsNullOrEmpty(token.Result))
        {
           return Ok(token.Result);
        }

        return Unauthorized();
    }
}
