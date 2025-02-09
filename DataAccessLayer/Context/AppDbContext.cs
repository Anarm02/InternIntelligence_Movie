using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
	public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid>
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Movie> Movies { get; set; }
	}
}
