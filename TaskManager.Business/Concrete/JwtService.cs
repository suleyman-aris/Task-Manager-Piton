using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Business.Abstract;
using TaskManager.DataAccess.Abstract;

namespace TaskManager.Business.Concrete;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    private readonly IUserDAL _userService;

    public JwtService(IConfiguration configuration, IUserDAL userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    public async Task<string> GenerateToken(string username, string password)
    {

        var IsUser = await _userService.GetUser(username, password);

        if (IsUser == null)
            throw new Exception("User bulunamadı.");

        var jwtSettings = _configuration.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, IsUser.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["TokenExpirationMinutes"])),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
