using VortiDex.Model;

namespace VortiDex.Dtos.Responses.DtosPokedex;

public class ReadPokedexDtoWithRelations
{
    public required int Id { get; set; }

    public required int TrainerId { get; set; }

    public required ICollection<Pokemon> Pokemons { get; set; }
}
