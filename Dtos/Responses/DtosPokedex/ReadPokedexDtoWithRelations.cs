using VortiDex.Dtos.Responses.DtosPokemon;

namespace VortiDex.Dtos.Responses.DtosPokedex;

public class ReadPokedexDtoWithRelations
{
    public required int Id { get; set; }

    public required int TrainerId { get; set; }

    public required ICollection<ReadPokemonDto> Pokemons { get; set; }
}
