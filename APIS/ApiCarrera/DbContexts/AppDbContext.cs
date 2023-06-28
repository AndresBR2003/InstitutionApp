using ApiCarrera.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCarrera.DbContexts
{
    public class AppDbContext :DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Carrera> Carreras { get; set; }
    }
}
