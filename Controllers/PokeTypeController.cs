using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosPokeType;
using VortiDex.Dtos.Request.DtosTrainer;
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

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var pokeType = _pokeTypeServ.GetById(id);

        if (pokeType is null) return NotFound();

        return Ok(pokeType);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreatePokeTypeDto dto)
    {
        var pokeType = _pokeTypeServ.CreateServ(dto);

        return CreatedAtAction(nameof(GetById), new { id = pokeType.Name }, pokeType);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] UpdatePokeTypeDto dto)
    {
        var pokeType = _pokeTypeServ
           .UpdateServ(id, dto);

        return Ok(pokeType);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _pokeTypeServ
            .Delete(id);

        return NoContent();
    }
}
