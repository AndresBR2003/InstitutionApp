using ApiCarrera.Dtos;
using ApiCarrera.Model;

namespace ApiCarrera.Repository
{
    public interface ICarreraRepository
    {

        Task<IEnumerable<Carrera>> GetAllCarreras();

        Task<Carrera> createCarrera(Carrera carrera);

        Task<bool> deleteCarrera(int carreraId);

        Task<Carrera> updateCarrera(Carrera carrera);

        Task<Carrera> GetCarrerasById(int carreraId);

        Task<IEnumerable<CarreraDto>> GetCarrerasByCategoria(string codigoCategoria);
    }
}
