using EntityLayer.DTOs.Auth;
using EntityLayer.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.Services.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Concrete
{
	public class TokenService : ITokenService
	{
		private readonly IConfiguration configuration;
public TokenService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public AuthResponseDto CreateToken(AppUser user)
		{
			var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(configuration["Jwt:TokenValidityInMinutes"]));
			var refreshTokenExpiration = DateTime.UtcNow.AddDays(Convert.ToDouble(configuration["Jwt:RefreshTokenValidityInDays"]));
			Claim[] claims = new Claim[] {
				new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Iat,DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()),
				new Claim(ClaimTypes.Email,user.Email),
				new Claim(ClaimTypes.Name,user.FullName)
			};
			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]));
			SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			JwtSecurityToken securityToken = new JwtSecurityToken(issuer: configuration["Jwt:Issuer"],
				audience: configuration["Jwt:Audience"],
				claims: claims,
				expires: expiration,
				signingCredentials: credentials);
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			string token = tokenHandler.WriteToken(securityToken);
			return new()
			{
				AccessToken = token,
				ExpirationDate = expiration,
				RefreshToken = GenerateRefreshToken(),
				RefreshTokenExpiration = refreshTokenExpiration
			};
		}

		public string GenerateRefreshToken()
		{
			byte[] bytes = new byte[64];
			var rng = RandomNumberGenerator.Create();
			rng.GetBytes(bytes);
			return Convert.ToBase64String(bytes);
		}
	}
}
