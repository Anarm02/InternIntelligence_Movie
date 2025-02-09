using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Movie
{
	public class TmdbResponseDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Overview { get; set; }
		public string PosterPath { get; set; }
		public double VoteAverage { get; set; }
		public string ReleaseDate { get; set; }
	}
}
