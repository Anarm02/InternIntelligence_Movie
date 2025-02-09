using EntityLayer.DTOs.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}
		[HttpPost("[action]")]
		public async Task<IActionResult> Login(LoginDto loginDto)
		{
			try
			{
				var res = await _authService.Login(loginDto);
				return Ok(res);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("ValidationErrors", ex.Message);
				return BadRequest(ModelState);
			}
		}
		[HttpPost("[action]")]
		public async Task<IActionResult> Register(RegisterDto registerDto)
		{
			try
			{
				var res = await _authService.Register(registerDto);
				return Ok(res);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("ValidationErrors", ex.Message);
				return BadRequest(ModelState);
			}
		}
	}
}
