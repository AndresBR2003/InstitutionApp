using ApiCurso.Models;
using ApiCurso.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCurso.Controllers
{
    [Route("/api/curso")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private ICursoRepository cursoRepository;

        public CursoController(ICursoRepository cursoRepository)
        {
            this.cursoRepository = cursoRepository;
        }

        [Route("/getAllCursos")]
        [HttpGet]
        public async Task<IEnumerable<Curso>> getAllCursos()
        {
            return await cursoRepository.getAllCursos();
        }

        [Route("/getCursoById/{CursoId}")]
        [HttpGet]
        public async Task<Curso> getCursoById(int CursoId)
        {
            return await cursoRepository.getCursoById(CursoId);
        }

        [Route("/deleteCurso/{CursoId}")]
        [HttpDelete]
        public async Task<bool> deleteCurso(int CursoId)
        {
            return await cursoRepository.deleteCurso(CursoId);
        }

        [Route("/createCurso")]
        [HttpPost]
        public async Task<Curso> createCurso(Curso curso)
        {
            return await cursoRepository.createCurso(curso);
        }

        [Route("/updateCurso")]
        [HttpPost]
        public async Task<Curso> updateCurso(Curso curso)
        {
            return await cursoRepository.updateCurso(curso);
        }

    }
}
