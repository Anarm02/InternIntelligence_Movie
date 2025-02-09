using EntityLayer.DTOs.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		private readonly IMovieService movieService;

		public MovieController(IMovieService movieService)
		{
			this.movieService = movieService;
		}
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> CreateMovie(AddMovieDto dto)
		{
			try
			{
				await movieService.CreateMovie(dto);
				return StatusCode(201);
			}
			catch (Exception ex)
			{

				return StatusCode(400, new {Message=$"Something went wrong while creating movie {ex.Message}"});
			}
		}
		[HttpGet]
	
		public async Task<IActionResult> GetAllMovies()
		{
			var movies = await movieService.GetAllMovies();
			return Ok(movies);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetMovie(int id)
		{
			var movie = await movieService.GetMovieById(id);
			return Ok(movie);
		}
		[HttpPut]
		[Authorize]
		public async Task<IActionResult> UpdateMovie(UpdateMovieDto dto)
		{
			var movie=await movieService.UpdateMovie(dto);
			return Ok(movie);
		}
		[HttpDelete]
		[Authorize]
		public async Task<IActionResult> DeleteMovie(int id)
		{
			await movieService.DeleteMovieById(id);
			return StatusCode(204);
		}
	}
}
