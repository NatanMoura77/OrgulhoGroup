using Microsoft.EntityFrameworkCore;
using VortiDex.Model;

namespace VortiDex.Infra.Repositories;

public class PokedexRepository
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
}