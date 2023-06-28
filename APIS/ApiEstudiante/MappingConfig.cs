using ApiEstudiante.Dto;
using ApiEstudiante.Model;
using AutoMapper;

namespace ApiEstudiante
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Estudiante, EstudianteDto>();
                config.CreateMap<EstudianteDto, Estudiante>();
            });
            return mappingConfig;
        }
    }
}
