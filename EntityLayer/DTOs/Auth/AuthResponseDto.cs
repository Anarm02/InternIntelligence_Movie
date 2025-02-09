using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Auth
{
	public class AuthResponseDto
	{
		public string? AccessToken { get; set; }
		public DateTime? ExpirationDate { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime? RefreshTokenExpiration { get; set; }	
	}
}
