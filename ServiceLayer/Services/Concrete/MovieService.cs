using AutoMapper;
using DataAccessLayer.Context;
using EntityLayer.DTOs.Movie;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Concrete
{
	public class MovieService : IMovieService
	{
		private readonly AppDbContext appDbContext;
		private readonly IMapper mapper;

		public MovieService(AppDbContext appDbContext, IMapper mapper)
		{
			this.appDbContext = appDbContext;
			this.mapper = mapper;
		}

		public async Task CreateMovie(AddMovieDto dto)
		{
			var map = mapper.Map<Movie>(dto);
			await appDbContext.Movies.AddAsync(map);
			await appDbContext.SaveChangesAsync();
		}

		public async Task DeleteMovieById(int id)
		{
			var movie = await appDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
			movie.isDeleted = true;
			appDbContext.Movies.Update(movie);
			await appDbContext.SaveChangesAsync();
		}

		public async Task<List<Movie>> GetAllMovies()
		{
			return await appDbContext.Movies.Where(x=>!x.isDeleted).ToListAsync();
		}

		public async Task<Movie> GetMovieById(int id)
		{
			return await appDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id && !x.isDeleted);
		}

		public async Task<Movie> UpdateMovie(UpdateMovieDto updateMovieDto)
		{

			var movie = await appDbContext.Movies
		.FirstOrDefaultAsync(x => x.Id == updateMovieDto.Id && !x.isDeleted);

			if (movie == null)
			{
				throw new Exception("Movie not found!");
			}

			
			mapper.Map(updateMovieDto, movie);

			appDbContext.Update(movie);
			await appDbContext.SaveChangesAsync();

			return movie;
		}
	}
}
