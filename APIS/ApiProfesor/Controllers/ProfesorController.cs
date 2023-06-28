using ApiProfesor.Dtos;
using ApiProfesor.Models;
using ApiProfesor.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiProfesor.Controllers
{
    [Route("/api/profesor")]
    [ApiController]
    public class ProfesorController:ControllerBase
    {
        private IProfesorRepository profesorRepository;
        private ResponseDto responseDto;

        public ProfesorController(IProfesorRepository profesorRepository)
        {
            this.profesorRepository = profesorRepository;
            this.responseDto = new ResponseDto();
        }

        [Route("/getAllProfesores")]
        [HttpGet]
        public async Task<IEnumerable<Profesor>> getAllProfesores()
        {
            return await profesorRepository.getAllProfesores();
        }

        [Route("/getProfesorById/{ProfesorId}")]
        [HttpGet]
        public async Task<Profesor> getProfesorById(int ProfesorId)
        {
            return await profesorRepository.getProfesorById(ProfesorId);
        }

        [Route("/deleteProfesor/{ProfesorId}")]
        [HttpDelete]
        public async Task<bool> deleteProfesor(int ProfesorId)
        {
            return await profesorRepository.deleteProfesor(ProfesorId);
        }

        [Route("/createProfesor")]
        [HttpPost]
        public async Task<Profesor> createProfesor(Profesor profesor)
        {
            return await profesorRepository.createProfesor(profesor);
        }

        [Route("/updateProfesor")]
        [HttpPost]
        public async Task<Profesor> updateProfesor(Profesor profesor)
        {
            return await profesorRepository.updateProfesor(profesor);
        }



        [Route("/getByCodigoCurso/{CodigoCurso}")]
        [HttpGet]
        public async Task<Object> getByCodigoCurso(string CodigoCurso)
        {
            try
            {
                IEnumerable<ProfesorDto> profesorDtos = await profesorRepository
                    .getProfesorByCodigoCurso(CodigoCurso);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = profesorDtos;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }
    }
}
