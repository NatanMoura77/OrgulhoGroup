using VortiDex.Model;

namespace VortiDex.Infra.Repositories;

public class PokeTypeRepository
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

    public PokeType? FindById(string name)
    {
       return _context.PokeTypes.FirstOrDefault(pokeType => pokeType.Name == name);
    }

    public ICollection<PokeType> GetAllRep()
    {
       return _context
            .PokeTypes
            .ToList();
    }

    public PokeType UpdateRep(PokeType pokeType)
    {
        _context.PokeTypes.Update(pokeType);
        _context.SaveChanges();

        return (pokeType);
    }

    public PokeType DeleteRep(PokeType pokeType)
    {
        _context.PokeTypes.Remove(pokeType);
        _context.SaveChanges();

        return (pokeType);
    }

    public bool Exists(string name)
    {
       return _context.PokeTypes.Any(pokeType => pokeType.Name == name);
    }
}
