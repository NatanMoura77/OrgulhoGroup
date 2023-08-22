using VortiDex.Model;

namespace VortiDex.Infra.Repositories.Interfaces;

public interface ISquadRepository : IRepository<Squad>
{
    Squad AddPokemonToSquad(Squad squad, int pokemonId);
    Squad DeletePokemonFromSquad(Squad squad, int pokemonId);
}
