using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Movie
{
	public class AddMovieDto
	{
		[Required]
		[StringLength(100)]
		public string Title { get; set; }
		[Required]
		public string Genre { get; set; }
		[Required]
		public DateTime ReleaseDate { get; set; }
		[Required]
		public string Author { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		[Range(0, 10)]
		public int Rating { get; set; }
	}
}
