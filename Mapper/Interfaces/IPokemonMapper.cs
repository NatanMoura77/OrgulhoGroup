using VortiDex.Dtos.Request.DtosPokemon;
using VortiDex.Dtos.Responses.DtosPokemon;
using VortiDex.Model;

namespace VortiDex.Mapper.Interfaces;

public interface IPokemonMapper : IGeralMapper<Pokemon, CreatePokemonDto, UpdatePokemonDto, ReadPokemonDto, ReadPokemonDtoWithRelations>
{
}