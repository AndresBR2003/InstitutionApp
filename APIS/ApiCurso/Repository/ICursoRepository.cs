using ApiCurso.Models;

namespace ApiCurso.Repository
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> getAllCursos();
        Task<Curso> createCurso(Curso curso);
        Task<bool> deleteCurso(int CursoId);
        Task<Curso> updateCurso(Curso curso);
        Task<Curso> getCursoById(int CursoId);
    }
}
