using Microsoft.EntityFrameworkCore;
using EuroSkills.Models;

namespace EuroSkills.Data
{
    public class VersenyDbContext : DbContext
    {
        public VersenyDbContext(DbContextOptions<VersenyDbContext> options)
            : base(options)
        {

        }

        public DbSet<Orszag> Orszagok { get; set; }
        public DbSet<Versenyzo> Versenyzok { get; set; }
        public DbSet<Szakma> Szakmak { get; set; }

    }
}