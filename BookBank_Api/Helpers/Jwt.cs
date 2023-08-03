using System;
using BookBank_Api.Models;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace BookBank_Api.Helpers
{
	public class Jwt
	{
        public string Generate(string key, UserModel user, string issuer, string audience)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Crear los claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.name),
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.GivenName, user.name),
                new Claim(ClaimTypes.Surname, user.name),
                new Claim(ClaimTypes.Role, user.rol),
            };


            // Crear el token

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

