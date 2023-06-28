using ApiProfesor.Dtos;
using ApiProfesor.Models;
using AutoMapper;

namespace ApiProfesor
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Profesor, ProfesorDto>();
                config.CreateMap<ProfesorDto, Profesor>();
            });
            return mappingConfig;
        }
    }
}
