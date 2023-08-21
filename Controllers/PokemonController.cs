using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosPokemon;
using VortiDex.Services;

namespace VortiDex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonServices _pokemonServices;

        public PokemonController(PokemonServices pokeServices)
        {
            _pokemonServices = pokeServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pokemon = _pokemonServices.GetAllServ();
            return Ok(pokemon);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pokemon = _pokemonServices.GetById(id);

            return Ok(pokemon);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePokemonDto dto)
        {
            var pokemon = _pokemonServices.CreateServ(dto);

            return CreatedAtAction(nameof(GetById), new { id = pokemon.Id }, pokemon);
        }

        [HttpPost("{id}/Skill{skillId}")]
        public IActionResult LearnMove(int id, int skillId)
        {
            var pokemon = _pokemonServices.LearnMoveServ(id, skillId);

            return Ok(pokemon);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdatePokemonDto dto)
        {
            var pokemon = _pokemonServices.UpdateServ(id, dto);

            return Ok(pokemon);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pokemonServices
                .Delete(id);

            return NoContent();
        }
    }
}
