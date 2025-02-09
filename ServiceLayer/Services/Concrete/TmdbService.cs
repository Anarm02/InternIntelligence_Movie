using EntityLayer.DTOs.Movie;
using Microsoft.Extensions.Configuration;
using ServiceLayer.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Concrete
{
	public class TmdbService : ITmdbService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;
		public TmdbService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri(configuration["Tmdb:BaseUrl"]);
			_apiKey = configuration["Tmdb:apiKey"];
		}

		public async Task<FilmDetailsDto> GetFilmDetails(int id)
		{
			try
			{
				var response = await _httpClient.GetAsync($"movie/{id}?api_key={_apiKey}");
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadFromJsonAsync<FilmDetailsDto>();
			}
			catch (Exception ex)
			{

				throw new Exception($"Error in getting film details: {ex.Message}");
			}
		}

		public async Task<IEnumerable<TmdbResponseDto>> GetPopularFilmsAsync()
		{
			try
			{
				var response = await _httpClient.GetAsync($"movie/popular?api_key={_apiKey}");
				response.EnsureSuccessStatusCode();

				var result = await response.Content.ReadFromJsonAsync<TmdbApiResponse>();
				return result.Results;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error in GetPopularFilmsAsync: {ex.Message}");
			}
		}

		public async Task<IEnumerable<TmdbResponseDto>> SearchFilms(string query)
		{
			try
			{
				var response=await _httpClient.GetAsync($"search/movie?api_key={_apiKey}&query={Uri.EscapeDataString(query)}");
				response.EnsureSuccessStatusCode();
				var result = await response.Content.ReadFromJsonAsync<TmdbApiResponse>();
				return result.Results;
			}
			catch (Exception ex)
			{

				throw new Exception($"Error in searching films : {ex.Message}");
			}
		}
	}
}
