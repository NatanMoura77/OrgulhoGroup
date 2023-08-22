using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosPokemon;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Services;
using VortiDex.Services.Interface;

namespace VortiDex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonServices;

        public PokemonController(IPokemonService pokeServices)
        {
            _pokemonServices = pokeServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pokemon = _pokemonServices.ReadAll();
            return Ok(pokemon);
        }

        [HttpGet("{id}")]
        public IActionResult ReadById(int id)
        {
            try
            {
                var pokemon = _pokemonServices.ReadById(id);

                return Ok(pokemon);
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePokemonDto dto)
        {
            try
            {
                var pokemon = _pokemonServices.Create(dto);

                return CreatedAtAction(nameof(ReadById), new { id = pokemon.Id }, pokemon);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("{id}/Skill{skillId}")]
        public IActionResult LearnMove(int id, int skillId)
        {
            try
            {
                var pokemon = _pokemonServices.LearnMoveServ(id, skillId);

                return Ok(pokemon);
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdatePokemonDto dto)
        {
            var pokemon = _pokemonServices.Update(id, dto);

            return Ok(pokemon);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _pokemonServices.Delete(id);

                return NoContent();
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
