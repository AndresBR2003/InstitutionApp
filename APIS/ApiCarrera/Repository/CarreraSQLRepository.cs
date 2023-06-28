using ApiCarrera.DbContexts;
using ApiCarrera.Dtos;
using ApiCarrera.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiCarrera.Repository
{
    public class CarreraSQLRepository : ICarreraRepository
    {
        private AppDbContext dbContext;
        private IMapper mapper;

        public CarreraSQLRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Carrera> createCarrera(Carrera carrera)
        {
            dbContext.Carreras.Add(carrera);
            await dbContext.SaveChangesAsync();
            return carrera;
        }

        public async Task<bool> deleteCarrera(int carreraId)
        {
            var carrera = await dbContext.Carreras.FirstOrDefaultAsync(carrera => carrera.carreraId == carreraId);
            if (carrera == null)
            {
                return false;
            }
            dbContext.Remove(carrera);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Carrera>> GetAllCarreras()
        {
            return await this.dbContext.Carreras.ToListAsync();
        }

        public async Task<IEnumerable<CarreraDto>> GetCarrerasByCategoria(string codigoCategoria)
        {
            List<Carrera> carreras = await dbContext.Carreras.Where(carrera =>
            carrera.codigoCategoria == codigoCategoria).ToListAsync();
            return mapper.Map<List<CarreraDto>>(carreras);
        }

        public async Task<Carrera> GetCarrerasById(int carreraId)
        {
            var carrera = await dbContext.Carreras.Where(carrera => carrera.carreraId == carreraId)
                .FirstOrDefaultAsync();
            return carrera;
        }

        public async Task<Carrera> updateCarrera(Carrera carrera)
        {
            dbContext.Carreras.Update(carrera);
            await dbContext.SaveChangesAsync();
            return carrera;
        }
    }
}
