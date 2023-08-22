using VortiDex.Dtos.Request.DtosPokedex;
using VortiDex.Dtos.Responses.DtosPokedex;
using VortiDex.Model;

namespace VortiDex.Services.Interface;

public interface IPokedexService : IService<Pokedex, CreatePokedexDto, UpdatePokedexDto, ReadPokedexDto, ReadPokedexDtoWithRelations>
{
    ReadPokedexDtoWithRelations AddPokemonToPokedex(int pokedexId, int pokemonId);
}
