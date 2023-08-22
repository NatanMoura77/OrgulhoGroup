﻿using Microsoft.EntityFrameworkCore;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Infra.Repositories.Interfaces;
using VortiDex.Model;

namespace VortiDex.Infra.Repositories;

public class PokedexRepository : IPokedexRepository
{
    private readonly PokeContext _context;

    public PokedexRepository(PokeContext context)
    {
        _context = context;
    }

    public Pokedex CreateRep(Pokedex pokedex)
    {
        _context.Pokedex.Add(pokedex);
        _context.SaveChanges();

        return(pokedex);
    }

    public Pokedex? FindById(int id)
    {
       return _context.Pokedex.FirstOrDefault(pokedex => pokedex.Id == id);
    }

    public ICollection<Pokedex> GetAllRep()
    {
       return _context.Pokedex
            .Include(pokedex => pokedex.Pokemons).ToList();
    }

    public Pokedex UpdateRep(Pokedex pokedex)
    {
        _context.Pokedex.Update(pokedex);
        _context.SaveChanges();

        return(pokedex);
    }

    public Pokedex DeleteRep(Pokedex pokedex)
    {
        _context.Pokedex.Remove(pokedex);
        _context.SaveChanges();

        return(pokedex);
    }

    public bool Exists(int id)
    {
        return _context.Pokedex.Any(pokedex => pokedex.Id == id);
    }

    public Pokedex AddPokemonToPokedex(Pokedex pokedex, int pokemonId)
    {
        var pokemon = _context.Pokemon.Find(pokemonId) ?? throw new PokemonNotFoundException();

        pokedex.Pokemons.Add(pokemon);

        _context.SaveChanges();

        return(pokedex);
    }
}