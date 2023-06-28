using ApiCarrera.Dtos;
using ApiCarrera.Model;
using ApiCarrera.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCarrera.Controllers
{
    [Route("api/carrera/[controller]")]
    [ApiController]
    public class CarreraController:ControllerBase
    {
        private ICarreraRepository carreraRepository;
        private ResponseDto responseDto;

        public CarreraController(ICarreraRepository carreraRepository)
        {
            this.carreraRepository = carreraRepository;
            this.responseDto = new ResponseDto();
        }

        [Route("/GetAllCarreras")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrera>>> GetAllCarreras()
        {
            return StatusCode(StatusCodes.Status200OK,
                await carreraRepository.GetAllCarreras());
        }

        [Route("/createCarrera")]
        [HttpPost]
        public async Task<ActionResult<Carrera>> createEstudiante(Carrera carrera)
        {//201
            return StatusCode(StatusCodes.Status201Created,
                await carreraRepository.createCarrera(carrera));
        }

        [Route("/deleteCarrera/{carreraId}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> deleteCarrera(int carreraId)
        {

            return StatusCode(StatusCodes.Status200OK,
              await carreraRepository.deleteCarrera(carreraId));
        }

        [Route("/GetCarrerasById/{id}")]
        [HttpGet]
        public async Task<object> GetCarrerasById(int carreraId)
        {
            return await carreraRepository.GetCarrerasById(carreraId);
        }

        [Route("/GetCarrerasByCategoria/{codigoCategoria}")]
        [HttpGet]
        public async Task<object> GetCarrerasByCategoria(string codigoCategoria)
        {
            try
            {
                IEnumerable<CarreraDto> carreraDtos = await carreraRepository
                    .GetCarrerasByCategoria(codigoCategoria);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = carreraDtos;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }

        [Route("/updateCarrera")]
        [HttpPost]
        public async Task<ActionResult<Carrera>> updateEstudiante(Carrera carrera)
        {
            return Ok(await carreraRepository.updateCarrera(carrera));

        }
    }
}
