using EntityLayer.DTOs.Movie;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Abstract
{
	public interface IMovieService
	{
		Task CreateMovie(AddMovieDto dto);
		Task<List<Movie>> GetAllMovies();
		Task<Movie> GetMovieById(int id);
		Task<Movie> UpdateMovie(UpdateMovieDto updateMovieDto);
		Task DeleteMovieById(int id);
	}
}
