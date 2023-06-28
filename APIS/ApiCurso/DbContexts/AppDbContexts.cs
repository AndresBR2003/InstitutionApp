using ApiCurso.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCurso.DbContexts
{
    public class AppDbContexts:DbContext
    {
        public AppDbContexts()
        {
        }

        public AppDbContexts(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }
    }
}
