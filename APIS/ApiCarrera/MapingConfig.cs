using ApiCarrera.Dtos;
using ApiCarrera.Model;
using AutoMapper;

namespace ApiCarrera
{
    public class MapingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CarreraDto, Carrera>();
                config.CreateMap<Carrera, CarreraDto>();
            });
            return mappingConfig;
        }
    }
}
