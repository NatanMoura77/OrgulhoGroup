using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosSquad;
using VortiDex.Handlers;
using VortiDex.Services;
using VortiDex.Services.Interface;

namespace VortiDex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquadController : ControllerBase
    {
        private readonly ISquadService _squadServ;

        public SquadController(ISquadService squadServ)
        {
            _squadServ = squadServ;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var squad = _squadServ.ReadAll();
            return Ok(squad);
        }

        [HttpGet("{id}")]
        public IActionResult ReadById(int id)
        {
            try
            {
                var squad = _squadServ.ReadById(id);
                return Ok(squad);
            }
            catch (Exception exception)
            {
                return ControllerExceptionHandler.HandleException(exception);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSquadDto dto)
        {
            try
            {
                var squad = _squadServ.Create(dto);

                return CreatedAtAction(nameof(ReadById), new { id = squad.Id }, squad);
            }
            catch (Exception exception)
            {
                return ControllerExceptionHandler.HandleException(exception);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSquadDto dto)
        {
            try
            {
                var squad = _squadServ
                   .Update(id, dto);

                return Ok(squad);
            }
            catch (Exception exception)
            {
                return ControllerExceptionHandler.HandleException(exception);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _squadServ.Delete(id);

                return NoContent();
            }
            catch (Exception exception)
            {
                return ControllerExceptionHandler.HandleException(exception);
            }
        }

        [HttpPost("{id}/pokemon/{pokemonId}")]
        public IActionResult AddPokemonToSquad(int id, int pokemonId)
        {
            try
            {
                var squad = _squadServ.AddPokemonToSquad(id, pokemonId);

                return Ok(squad);
            }
            catch (Exception exception)
            {
                return ControllerExceptionHandler.HandleException(exception);
            }
        }

        [HttpDelete("{id}/pokemon/{pokemonId}")]

        public IActionResult DeletePokemonFromSquad(int id, int pokemonId)
        {
            try
            {
                var squad = _squadServ
                    .DeletePokemonFromSquad(id, pokemonId);

                return Ok(squad);
            }
            catch (Exception exception)
            {
                return ControllerExceptionHandler.HandleException(exception);
            }
        }
    }
}
