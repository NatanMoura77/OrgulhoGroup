using Microsoft.EntityFrameworkCore;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Model;

namespace VortiDex.Infra.Repositories;

public class PokemonRepository
{
    private readonly PokeContext _context;

    public PokemonRepository(PokeContext context)
    {
        _context = context;
    }

    public Pokemon CreateRep(Pokemon pokemon)
    {
        var pokeTypes = new List<PokeType>();

        foreach (string poketype in pokemon.PokeTypesId)
        {
            pokeTypes =
                _context.PokeTypes
                .Where(pokeType => pokeType.Name == poketype)
                .ToList();
        }

        pokemon.PokeTypes = pokeTypes;

        _context.Pokemon.Add(pokemon);
        _context.SaveChanges();

        return (pokemon);
    }

    public Pokemon? FindById(int id)
    {
        var pokemon = 
            _context.Pokemon
            .Include(pokemon => pokemon.PokeTypes)
            .Include(pokemon => pokemon.Skills)
            .FirstOrDefault(pokemon => pokemon.Id == id);

        return
             _context.Pokemon
             .FirstOrDefault(pokemon => pokemon.Id == id);
    }

    public ICollection<Pokemon> GetAllRep()
    {
        var pokemon = _context.Pokemon.ToList();

        return _context.Pokemon
            .Include(pokemon => pokemon.Skills)
            .Include(pokemon => pokemon.PokeTypes)
            .ToList();
    }

    public Pokemon UpdateRep(Pokemon pokemon)
    {
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

    public bool Exists(int id)
    {
        return _context.Pokemon.Any(pokemon => pokemon.Id == id);
    }

    public Pokemon LearnMoveRep(Pokemon pokemon, int skillId)
    {
        var skill = _context.Skills.FirstOrDefault(skill => skill.Id == skillId) ?? throw new SkillNotFoundException();

        pokemon.Skills.Add(skill);

        _context.SaveChanges();

        return (pokemon);
    }
}