using EntityLayer.DTOs.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Abstract
{
	public interface ITmdbService
	{
		Task<IEnumerable<TmdbResponseDto>> GetPopularFilmsAsync();
		Task<FilmDetailsDto> GetFilmDetails(int id);
		Task<IEnumerable<TmdbResponseDto>> SearchFilms(string query);
	}
}
