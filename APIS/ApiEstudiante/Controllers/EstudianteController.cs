
using ApiEstudiante.Dto;
using ApiEstudiante.Model;
using ApiEstudiante.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstudiante.Controllers
{
    [Route("/api/estudiante/[controller]")]
    [ApiController]
    public class EstudianteController:ControllerBase
    {
        private IEstudianteRepository estudianteRepository;
        private ResponeDto responseDto;


        public EstudianteController(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
            this.responseDto = new ResponeDto();

        }

        [Route("/GetAllEstudiantes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetAllEstudiantes()
        {
            return StatusCode(StatusCodes.Status200OK,
                await estudianteRepository.GetAllEstudiantes());
        }

        [Route("/createEstudiante")]
        [HttpPost]
        public async Task<ActionResult<Estudiante>> createEstudiante(Estudiante estudiante)
        {//201
            return StatusCode(StatusCodes.Status201Created,
                await estudianteRepository.createEstudiante(estudiante));
        }

        [Route("/updateEstudiante")]
        [HttpPost]
        public async Task<ActionResult<Estudiante>> updateEstudiante(Estudiante estudiante)
        {
            return Ok(await estudianteRepository.updateEstudiante(estudiante));

        }

        [Route("/deleteEstudiante/{id}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> deleteEstudiante(int id)
        {

            return StatusCode(StatusCodes.Status200OK,
              await estudianteRepository.deleteEstudiante(id));
        }

        [Route("/GetAllEstudianteById/{id}")]
        [HttpGet]
        public async Task<object> GetAllEstudiantesById(int id)
        {
            return await estudianteRepository.GetEstudiantesById(id);
        }

        [Route("/getByCodigoCurso/{CodigoCurso}")]
        [HttpGet]
        public async Task<Object> getByCodigoCurso(string CodigoCurso)
        {
            try
            {
                IEnumerable<EstudianteDto> estudianteDtos = await estudianteRepository
                    .getEstudianteByCodigoCurso(CodigoCurso);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = estudianteDtos;
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
