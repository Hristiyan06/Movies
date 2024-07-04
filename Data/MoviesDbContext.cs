using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options): base(options) 
        {
            
        }
        DbSet<Films> Films { get; set; }
        DbSet<Actors> Actors { get; set; }
    }
}
