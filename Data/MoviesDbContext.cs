using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options): base(options) 
        {
            
        }
        public DbSet<Films> Films { get; set; }
        public DbSet<Actors> Actors { get; set; }
    }
}
