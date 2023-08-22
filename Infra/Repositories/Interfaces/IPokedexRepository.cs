using VortiDex.Model;

namespace VortiDex.Infra.Repositories.Interfaces;

public interface IPokedexRepository : IRepository<Pokedex>
{
    Pokedex AddPokemonToPokedex(Pokedex pokedex, int pokemonId);
}
