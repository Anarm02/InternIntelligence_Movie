using EntityLayer.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Abstract
{
	public interface IAuthService
	{
		Task<AuthResponseDto> Login(LoginDto loginDto);
		Task<AuthResponseDto> Register(RegisterDto registerDto);
	}
}
