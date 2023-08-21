using Microsoft.EntityFrameworkCore;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Model;

namespace VortiDex.Infra.Repositories;

public class SquadRepository
{
    private readonly PokeContext _context;

    public SquadRepository(PokeContext context)
    {
        _context = context;
    }

    public Squad CreateRep(Squad squad)
    {
        _context.Squads.Add(squad);
        _context.SaveChanges();

        return (squad);
    }

    public Squad? FindById(int id)
    {
        return _context.Squads
            .Include(squad => squad.Trainer)
            .FirstOrDefault(squad => squad.Id == id);
    }

    public ICollection<Squad> GetAllRep()
    {
       return _context
            .Squads
            .Include(squad => squad.Pokemons)
            .ToList();
    }

    public Squad UpdateRep(Squad squad)
    {
        _context.Squads.Update(squad);
        _context.SaveChanges();

        return (squad);
    }

    public Squad DeleteRep(Squad squad)
    {
        _context.Squads.Remove(squad);
        _context.SaveChanges();

        return (squad);
    }

    public bool Exists(int id)
    {
       return _context.Squads.Any(squad => squad.Id == id);
    }

    public Squad AddPokemonToSquad(Squad squad, int pokemonId)
    {
        var pokemon = _context.Pokemon.FirstOrDefault(pokemon => pokemon.Id == pokemonId) ?? throw new PokemonNotFoundException();

        squad.Pokemons.Add(pokemon);

        _context.SaveChanges();
        return (squad);
    }
}
