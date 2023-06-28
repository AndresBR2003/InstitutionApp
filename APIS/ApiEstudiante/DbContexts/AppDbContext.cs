using ApiEstudiante.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiEstudiante.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}
