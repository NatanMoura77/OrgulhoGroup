using VortiDex.Dtos.Request.DtosPokemon;
using VortiDex.Dtos.Responses.DtosPokemon;
using VortiDex.Model;

namespace VortiDex.Services.Interface;

public interface IPokemonService : IService<Pokemon, CreatePokemonDto, UpdatePokemonDto, ReadPokemonDto, ReadPokemonDtoWithRelations>
{
    ReadPokemonDtoWithRelations LearnMoveServ(int pokemonId, int skillId);
}
