using Microsoft.EntityFrameworkCore;
using Webnovel.Models;

namespace Webnovel.Database
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Models.Webnovel> Webnovels { get; set; }

	}
}
