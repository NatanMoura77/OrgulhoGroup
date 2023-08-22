using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosSquad;
using VortiDex.Exceptions.NotFoundExceptions;
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
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSquadDto dto)
        {
            var squad = _squadServ.Create(dto);

            return CreatedAtAction(nameof(ReadById), new { id = squad.Id }, squad);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSquadDto dto)
        {
            var squad = _squadServ
               .Update(id, dto);

            return Ok(squad);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _squadServ.Delete(id);

                return NoContent();
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost("{id}/pokemon/{pokemonId}")]
        public IActionResult AddPokemonToSquad(int id, int pokemonId)
        {
            try
            {
                var pokemon = _squadServ.AddPokemonToSquad(id, pokemonId);

                return Ok(pokemon);
            }
            catch(NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
