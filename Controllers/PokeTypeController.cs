﻿using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosPokeType;
using VortiDex.Handlers;
using VortiDex.Services.Interface;

namespace VortiDex.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokeTypeController : ControllerBase
{
    private readonly IPokeTypeService _pokeTypeServ;

    public PokeTypeController(IPokeTypeService pokeTypeServ)
    {
        _pokeTypeServ = pokeTypeServ;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var pokeType = _pokeTypeServ.ReadAll();

        return Ok(pokeType);
    }

    [HttpGet("{id}")]
    public IActionResult ReadById(int id)
    {
        try
        {
            var pokeType = _pokeTypeServ.ReadById(id);

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
        try
        {
            var pokeType = _pokeTypeServ.Create(dto);

            return CreatedAtAction(nameof(ReadById), new { id = pokeType.Name }, pokeType);
        }
        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdatePokeTypeDto dto)
    {
        try
        {
            var pokeType = _pokeTypeServ.Update(id, dto);

            return Ok(pokeType);
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
            _pokeTypeServ.Delete(id);

            return NoContent();
        }
        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }
}
