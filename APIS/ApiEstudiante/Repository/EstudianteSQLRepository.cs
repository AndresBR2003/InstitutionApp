using ApiEstudiante.DbContexts;
using ApiEstudiante.Dto;
using ApiEstudiante.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiEstudiante.Repository
{
    public class EstudianteSQLRepository : IEstudianteRepository
    {
        private AppDbContext dbContext;
        private IMapper mapper;

        public EstudianteSQLRepository(AppDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Estudiante> createEstudiante(Estudiante estudiante)
        {
            dbContext.Estudiantes.Add(estudiante);
            await dbContext.SaveChangesAsync();
            return estudiante;
        }

        public async Task<bool> deleteEstudiante(int id)
        {
            var estudiante = await dbContext.Estudiantes.FirstOrDefaultAsync(c => c.estudianteId == id);
            if (estudiante == null)
            {
                return false;
            }
            dbContext.Remove(estudiante);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Estudiante>> GetAllEstudiantes()
        {
            return await this.dbContext.Estudiantes.ToListAsync();
        }


        public async Task<IEnumerable<EstudianteDto>> getEstudianteByCodigoCurso(string CodigoCurso)
        {
            List<Estudiante> estudiantes = await dbContext.Estudiantes.Where(estudiante =>
            estudiante.CodigoCurso == CodigoCurso).ToListAsync();
            return mapper.Map<List<EstudianteDto>>(estudiantes);
           
        }


        public async Task<Estudiante> GetEstudiantesById(int id)
        {
            var estudiante = await dbContext.Estudiantes.Where(estudiante => estudiante.estudianteId == id)
                .FirstOrDefaultAsync();
            return estudiante;
        }



        public async Task<Estudiante> updateEstudiante(Estudiante estudiante)
        {
            dbContext.Estudiantes.Update(estudiante);
            await dbContext.SaveChangesAsync();
            return estudiante;
        }
    }
}
