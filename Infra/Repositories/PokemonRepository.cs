using Microsoft.EntityFrameworkCore;
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
        _context.Pokemon.Add(pokemon);
        _context.SaveChanges();

        return (pokemon);
    }

    public Pokemon? FindById(int id)
    {
       return _context.Pokemon.FirstOrDefault(pokemon => pokemon.Id == id);
    }

    public ICollection<Pokemon> GetAllRep()
    {
       return _context.Pokemon
            .Include(pokemon => pokemon.PokeTypes)
            .ThenInclude(pokemon => pokemon.Skills)
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
}