using VortiDex.Model;

namespace VortiDex.Dtos.Responses.DtosPokemon;

public class ReadPokemonDtoWithRelations
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required double Height { get; set; }

    public required double Weight { get; set; }

    public required bool IsCatch { get; set; }

    public required string Picture { get; set; }

    public ICollection<PokeType> PokeTypes { get; set; }

    public ICollection<Skill> Skills { get; set; }
}
