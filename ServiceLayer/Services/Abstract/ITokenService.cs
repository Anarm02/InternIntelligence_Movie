using EntityLayer.DTOs.Auth;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Abstract
{
	public interface ITokenService
	{
		AuthResponseDto CreateToken(AppUser user);
		string GenerateRefreshToken();
	}
}
