using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosPokedex;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Handlers;
using VortiDex.Services;
using VortiDex.Services.Interface;

namespace VortiDex.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokedexController : ControllerBase
{
    private readonly IPokedexService _pokedexServices;

    public PokedexController(IPokedexService pokedexServices)
    {
        _pokedexServices = pokedexServices;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var pokedex = _pokedexServices.ReadAll();

        return Ok(pokedex);
    }

    [HttpGet("{id}")]
    public IActionResult ReadById(int id)
    {
        try
        {
            var pokedex = _pokedexServices.ReadById(id);

            return Ok(pokedex);
        }
        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }

    }

    [HttpPost]
    public IActionResult Create([FromBody] CreatePokedexDto dto)
    {
        var pokedex = _pokedexServices.Create(dto);

        return CreatedAtAction(nameof(ReadById), new { id = pokedex.Id }, pokedex);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdatePokedexDto dto)
    {
        var pokedex = _pokedexServices.Update(id, dto);

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
        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
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
        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }
}
