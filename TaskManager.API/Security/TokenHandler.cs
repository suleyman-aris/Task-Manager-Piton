﻿
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class TokenHandler
{
	public static Token CreateToken(IConfiguration configuration)
	{
		Token token = new();

        SymmetricSecurityKey securityKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

        SigningCredentials credentials = new SigningCredentials(securityKey,
            SecurityAlgorithms.HmacSha256);

        token.Expiration = DateTime.Now.AddMinutes(Convert.ToInt16(configuration
            ["Token:Expiration"]));

        JwtSecurityToken jwtSecurityToken = new(
            issuer: configuration["Token:Issuer"],
            audience: configuration["Token:Audience"],
            expires: token.Expiration,
            notBefore: DateTime.Now,
            signingCredentials: credentials
            );

        JwtSecurityToken tokenHandler = new();
        //token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);
        token.AccessToken = "";

        byte[] numbers = new byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(numbers);
        token.RefreshToken = Convert.ToBase64String(numbers);

        return token;
    }
}
