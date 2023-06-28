
using ApiEstudiante.Dto;
using ApiEstudiante.Model;

namespace ApiEstudiante.Repository
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<Estudiante>> GetAllEstudiantes();
        Task<IEnumerable<EstudianteDto>> getEstudianteByCodigoCurso(string CodigoCurso);

        Task<Estudiante> createEstudiante(Estudiante estudiante);

        Task<bool> deleteEstudiante(int id);

        Task<Estudiante> updateEstudiante(Estudiante estudiante);

        Task<Estudiante> GetEstudiantesById(int id);

    }
}
