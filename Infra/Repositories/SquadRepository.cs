using Microsoft.EntityFrameworkCore;
using VortiDex.Exceptions.BadRequestExceptions;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Infra.Repositories.Interfaces;
using VortiDex.Model;

namespace VortiDex.Infra.Repositories;

public class SquadRepository : ISquadRepository
{
    private readonly PokeContext _context;

    public SquadRepository(PokeContext context)
    {
        _context = context;
    }

    public Squad CreateRep(Squad squad)
    {
        if (Exists(squad))
        {
            throw new BadRequestException("Essa equipe já existe!");
        }

        _context.Squads.Add(squad);
        _context.SaveChanges();

        return (squad);
    }

    public Squad? FindById(int id)
    {
        return _context.Squads
            .Include(squad => squad.Trainer)
            .Include(squad => squad.Pokemons)
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

    public bool Exists(Squad squad)
    {
        return _context.Squads.Any(squadDb => squadDb.Name == squad.Name);
    }

    public bool ExistsPokemonInSquad(Squad squad, Pokemon pokemon)
    {
        return squad.Pokemons.Contains(pokemon);
    }

    public Squad AddPokemonToSquad(Squad squad, int pokemonId)
    {
        var pokemon =
            _context.Pokemon
            .FirstOrDefault(pokemon => pokemon.Id == pokemonId) ??
            throw new PokemonNotFoundException();

        if (ExistsPokemonInSquad(squad, pokemon))
        {
            throw new BadRequestException("O pokemon já está na equipe!");
        }

        pokemon.IsCatch = true;

        squad.Pokemons.Add(pokemon);

        _context.SaveChanges();
        return (squad);
    }

    public Squad DeletePokemonFromSquad(Squad squad, int pokemonId)
    {
        var pokemon =
            _context.Pokemon
            .FirstOrDefault(pokemon => pokemon.Id == pokemonId) ??
            throw new PokemonNotFoundException();

        if (!squad.Pokemons.Contains(pokemon))
            throw new BadRequestException("O pokemon não existe nessa equipe");

        squad.Pokemons.Remove(pokemon);

        _context.SaveChanges();

        return (squad);
    }
}
