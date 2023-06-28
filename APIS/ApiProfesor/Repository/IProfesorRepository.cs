using ApiProfesor.Dtos;
using ApiProfesor.Models;

namespace ApiProfesor.Repository
{
    public interface IProfesorRepository
    {
        Task<IEnumerable<Profesor>> getAllProfesores();
        Task<IEnumerable<ProfesorDto>> getProfesorByCodigoCurso(string CodigoCurso);

        Task<Profesor> createProfesor(Profesor profesor);
        Task<bool> deleteProfesor(int ProfesorId);
        Task<Profesor> updateProfesor(Profesor profesor);
        Task<Profesor> getProfesorById(int ProfesorId);
    }
}
