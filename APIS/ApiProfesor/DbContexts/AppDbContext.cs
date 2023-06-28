using ApiProfesor.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProfesor.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Profesor> Profesores { get; set; }
    }
}
