using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.Services.Abstract;
using ServiceLayer.Services.Concrete;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace ServiceLayer.Extensions
{
	public static class ServiceExtension
	{
		public static void AddServiceLayer(this IServiceCollection services, IConfiguration configuration)
		{
		
			services.AddHttpClient();
			services.AddScoped<IMovieService, MovieService>();
			services.AddScoped<ITmdbService, TmdbService>();
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IAuthService, AuthService>();
			var assembly = Assembly.GetExecutingAssembly();
			services.AddAutoMapper(assembly);
			services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();
			services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(opt =>
			{
				opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidIssuer = configuration["Jwt:Issuer"],
					ValidateAudience = true,
					ValidAudience = configuration["Jwt:Audience"],
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]))
				};
			});
			services.AddAuthorization();
		}
	}
}
