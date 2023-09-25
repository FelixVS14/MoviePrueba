using Microsoft.EntityFrameworkCore;
using MovieBack.Model; 

namespace MovieBack.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
