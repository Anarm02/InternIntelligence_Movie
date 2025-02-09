using AutoMapper;
using EntityLayer.DTOs.Movie;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
	public class MovieProfile:Profile
	{
		public MovieProfile()
		{
			CreateMap<AddMovieDto, Movie>().ReverseMap();
			CreateMap<UpdateMovieDto, Movie>().ReverseMap();
		}
	}
}
