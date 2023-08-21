using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosTrainer;
using VortiDex.Handlers;
using VortiDex.Services;

namespace VortiDex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly TrainerServices _trainerServ;

        public TrainerController(TrainerServices trainerServ)
        {
            _trainerServ = trainerServ;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var trainer = _trainerServ.GetAllServ();
            return Ok(trainer);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var trainer = _trainerServ.GetById(id);
                return Ok(trainer);
            }
            catch (Exception exception)
            {
                return ControllerExceptionHandler.HandleException(exception);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTrainerDto dto)
        {
            var trainer = _trainerServ.CreateServ(dto);

            return CreatedAtAction(nameof(GetById), new { id = trainer.Id }, trainer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTrainerDto dto)
        {
            var trainer =
                _trainerServ
                .UpdateServ(id, dto);

            return Ok(trainer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _trainerServ.Delete(id);

                return NoContent();
            }
            catch (Exception exception)
            {
                return ControllerExceptionHandler.HandleException(exception);
            }
        }
    }
}
