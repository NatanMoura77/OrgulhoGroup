using VortiDex.Model;

namespace VortiDex.Infra.Repositories.Interfaces;

public interface IPokemonRepository : IRepository<Pokemon>
{
    Pokemon LearnMoveRep(Pokemon pokemon, int skillId);
    bool Exists(Pokemon pokemon);
}
