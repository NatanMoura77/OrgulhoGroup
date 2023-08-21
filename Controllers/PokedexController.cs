using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosPokedex;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Services;

namespace VortiDex.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokedexController : ControllerBase
{
    private readonly PokedexServices _pokedexServices;

    public PokedexController(PokedexServices pokedexServices)
    {
        _pokedexServices = pokedexServices;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var pokedex = _pokedexServices.GetAllServ();

        return Ok(pokedex);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var pokedex = _pokedexServices.GetById(id);

            return Ok(pokedex);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }

    }

    [HttpPost]
    public IActionResult Create([FromBody] CreatePokedexDto dto)
    {
        var pokedex = _pokedexServices.CreateServ(dto);

        return CreatedAtAction(nameof(GetById), new { id = pokedex.Id }, pokedex);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdatePokedexDto dto)
    {
        var pokedex = _pokedexServices.UpdateServ(id, dto);

        return Ok(pokedex);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _pokedexServices.Delete(id);

            return NoContent();
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }

    }

    [HttpPost("{id}/pokemon/{pokemonId}")]
    public IActionResult AddPokemonToPokedex(int id, int pokemonId)
    {
        try
        {
            var pokedex = _pokedexServices.AddPokemonToPokedex(id, pokemonId);

            return Ok(pokedex);
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }      
    }
}
