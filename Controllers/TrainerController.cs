using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosTrainer;
using VortiDex.Handlers;
using VortiDex.Services;
using VortiDex.Services.Interface;

namespace VortiDex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerServ;

        public TrainerController(ITrainerService trainerServ)
        {
            _trainerServ = trainerServ;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var trainer = _trainerServ.ReadAll();
            return Ok(trainer);
        }

        [HttpGet("{id}")]
        public IActionResult ReadById(int id)
        {
            try
            {
                var trainer = _trainerServ.ReadById(id);
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
            var trainer = _trainerServ.Create(dto);

            return CreatedAtAction(nameof(ReadById), new { id = trainer.Id }, trainer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTrainerDto dto)
        {
            var trainer =
                _trainerServ
                .Update(id, dto);

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
