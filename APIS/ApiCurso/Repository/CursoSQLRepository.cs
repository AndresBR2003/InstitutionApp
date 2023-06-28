using ApiCurso.DbContexts;
using ApiCurso.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiCurso.Repository
{
    public class CursoSQLRepository : ICursoRepository
    {

        private AppDbContexts appDbContext;

        public CursoSQLRepository(AppDbContexts dbContext)
        {
            this.appDbContext = dbContext;
        }

        public async Task<Curso> createCurso(Curso curso)
        {
            appDbContext.Cursos.Add(curso);
            await appDbContext.SaveChangesAsync();
            return curso;
        }

        public async Task<bool> deleteCurso(int CursoId)
        {
            Curso curso = await this.appDbContext.Cursos
                .FirstOrDefaultAsync(curso => curso.CursoId == CursoId);
            if (curso == null)
            {
                return false;
            }
            appDbContext.Cursos.Remove(curso);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Curso>> getAllCursos()
        {
            return await appDbContext.Cursos.ToListAsync();
        }

        public async Task<Curso> getCursoById(int CursoId)
        {
            var curso = await appDbContext.Cursos.Where(c => c.CursoId == CursoId)
                .FirstOrDefaultAsync();
            return curso; 
        }

        public async Task<Curso> updateCurso(Curso curso)
        {
            appDbContext.Cursos.Update(curso);
            await appDbContext.SaveChangesAsync();
            return curso;
        }
    }
}
