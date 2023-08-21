using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosPokeType;
using VortiDex.Handlers;
using VortiDex.Services;

namespace VortiDex.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokeTypeController : ControllerBase
{
    private readonly PokeTypeServices _pokeTypeServ;

    public PokeTypeController(PokeTypeServices pokeTypeServ)
    {
        _pokeTypeServ = pokeTypeServ;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var pokeType = _pokeTypeServ.GetAllServ();

        return Ok(pokeType);
    }

    [HttpGet("{name}")]
    public IActionResult GetById(string name)
    {
        try
        {
            var pokeType = _pokeTypeServ.GetById(name);

            return Ok(pokeType);
        }
        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreatePokeTypeDto dto)
    {
        var pokeType = _pokeTypeServ.CreateServ(dto);

        return CreatedAtAction(nameof(GetById), new { id = pokeType.Name }, pokeType);
    }

    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody] UpdatePokeTypeDto dto)
    {
        var pokeType = _pokeTypeServ.UpdateServ(name, dto);

        return Ok(pokeType);
    }

    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
        try
        {
            _pokeTypeServ.Delete(name);

            return NoContent();
        }
        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }
}
