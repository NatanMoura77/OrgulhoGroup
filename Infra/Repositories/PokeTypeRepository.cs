using VortiDex.Infra.Repositories.Interfaces;
using VortiDex.Model;

namespace VortiDex.Infra.Repositories;

public class PokeTypeRepository : IPokeTypeRepository
{
    private readonly PokeContext _context;

    public PokeTypeRepository(PokeContext context)
    {
        _context = context;
    }

    public PokeType CreateRep(PokeType pokeType)
    {
        _context.PokeTypes.Add(pokeType);
        _context.SaveChanges();

        return (pokeType);
    }

    public PokeType? FindById(int id)
    {
       return _context.PokeTypes.FirstOrDefault(pokeType => pokeType.Id == id);
    }

    public ICollection<PokeType> GetAllRep()
    {
       return _context
            .PokeTypes
            .ToList();
    }

    public PokeType UpdateRep(PokeType pokeType)
    {
        DeleteRep(pokeType);

        CreateRep(pokeType);

        return (pokeType);
    }

    public PokeType DeleteRep(PokeType pokeType)
    {
        _context.PokeTypes.Remove(pokeType);
        _context.SaveChanges();

        return (pokeType);
    }

    public bool Exists(int id)
    {
       return _context.PokeTypes.Any(pokeType => pokeType.Id == id);
    }
}
