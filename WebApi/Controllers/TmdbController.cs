using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;
using ServiceLayer.Services.Concrete;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TmdbController : ControllerBase
	{
		private readonly ITmdbService tmdbService;

		public TmdbController(ITmdbService tmdbService)
		{
			this.tmdbService = tmdbService;
		}
		[HttpGet("popular")]
		public async Task<IActionResult> GetPopularFilms()
		{
			try
			{
				var films = await tmdbService.GetPopularFilmsAsync();
				return Ok(films);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { Message = $"An error occurred while fetching popular films. {ex.Message}" });
			}
		}
		[HttpGet("[action]/{id}")]
		public async Task<IActionResult> GetFilmDetails(int id)
		{
			try
			{
				var film=await tmdbService.GetFilmDetails(id);
				return Ok(film);
			}
			catch (Exception ex)
			{

				return StatusCode(500, new { Message = $"An error occurred while getting film details. {ex.Message}" });
			}
		}
		[HttpGet("[action]")]
		public async Task<IActionResult> SearchFilms(string query)
		{
			try
			{
				var films = await tmdbService.SearchFilms(query);
				return Ok(films);
			}
			catch (Exception ex)
			{

				return StatusCode(500, new { Message = $"An error occurred while searching films. {ex.Message}" });
				
			}
		}

	}
}
