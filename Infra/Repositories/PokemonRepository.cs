using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VortiDex.Exceptions.BadRequestExceptions;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Infra.Repositories.Interfaces;
using VortiDex.Model;

namespace VortiDex.Infra.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private readonly PokeContext _context;

    public PokemonRepository(PokeContext context)
    {
        _context = context;
    }

    public Pokemon CreateRep(Pokemon pokemon)
    {
        var pokeTypes = new List<PokeType>();

        foreach (int poketype in pokemon.PokeTypesId)
        {
            var pokeType = _context.PokeTypes.FirstOrDefault(pokeType => pokeType.Id == poketype)
                ?? throw new PokeTypeNotFoundException();

            pokeTypes.Add(pokeType);
          
        }

        if (Exists(pokemon))
        {
            throw new BadRequestException("Esse pokemon já existe!");
        }

        pokemon.PokeTypes = pokeTypes;

        _context.Pokemon.Add(pokemon);
        _context.SaveChanges();

        return (pokemon);
    }

    public Pokemon? FindById(int id)
    {
        return
            _context.Pokemon
            .Include(pokemon => pokemon.PokeTypes)
            .Include(pokemon => pokemon.Skills)
            .FirstOrDefault(pokemon => pokemon.Id == id);
    }

    public ICollection<Pokemon> GetAllRep()
    {
        return _context.Pokemon
            .Include(pokemon => pokemon.Skills)
            .Include(pokemon => pokemon.PokeTypes)
            .ToList();
    }

    public Pokemon UpdateRep(Pokemon pokemon)
    {
        var pokeTypes = new List<PokeType>();

        foreach (int poketype in pokemon.PokeTypesId)
        {
            var pokeType = _context.PokeTypes.FirstOrDefault(pokeType => pokeType.Id == poketype)
                ?? throw new PokeTypeNotFoundException();

            pokeTypes.Add(pokeType);
        }

        pokemon.PokeTypes = pokeTypes;

        _context.Pokemon.Update(pokemon);
        _context.SaveChanges();

        return (pokemon);
    }

    public Pokemon DeleteRep(Pokemon pokemon)
    {
        _context.Pokemon.Remove(pokemon);
        _context.SaveChanges();

        return (pokemon);
    }

    public bool Exists(Pokemon pokemon)
    {
        return _context.Pokemon.Any(pokemonDb => pokemonDb.Name == pokemon.Name);
    }

    public Pokemon LearnMoveRep(Pokemon pokemon, int skillId)
    {
        var skill = _context.Skills.FirstOrDefault(skill => skill.Id == skillId)
            ?? throw new SkillNotFoundException();

        pokemon.Skills.Add(skill);

        _context.SaveChanges();

        return (pokemon);
    }
}