using ApiProfesor.DbContexts;
using ApiProfesor.Dtos;
using ApiProfesor.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProfesor.Repository
{
    public class ProfesorSQLRepository : IProfesorRepository
    {
        private AppDbContext appDbContext;
        private IMapper mapper;

        public ProfesorSQLRepository(AppDbContext dbContext, IMapper mapper) { 
            this.appDbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Profesor> createProfesor(Profesor profesor)
        {
            appDbContext.Profesores.Add(profesor);
            await appDbContext.SaveChangesAsync();
            return profesor;
        }

        public async Task<bool> deleteProfesor(int ProfesorId)
        {
            Profesor profesor = await this.appDbContext.Profesores
                .FirstOrDefaultAsync(profesor => profesor.ProfesorId == ProfesorId);
            if(profesor == null)
            {
                return false;
            }
            appDbContext.Profesores.Remove(profesor);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Profesor>> getAllProfesores()
        {
            return await appDbContext.Profesores.ToListAsync();
        }

        public async Task<IEnumerable <ProfesorDto>> getProfesorByCodigoCurso(string CodigoCurso)
        {
            List<Profesor> profesores = await appDbContext.Profesores.Where(profesores =>
            profesores.CodigoCurso == CodigoCurso).ToListAsync();
            return mapper.Map<List<ProfesorDto>>(profesores);
        }

        public async Task<Profesor> getProfesorById(int ProfesorId)
        {
            var profesor = await appDbContext.Profesores.Where(p=>p.ProfesorId == ProfesorId)
                .FirstOrDefaultAsync();
            return profesor;
        }

        public async Task<Profesor> updateProfesor(Profesor profesor)
        {
            appDbContext.Profesores.Update(profesor);
            await appDbContext.SaveChangesAsync();
            return profesor;

        }
    }
}
