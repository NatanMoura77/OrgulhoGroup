using VortiDex.Dtos.Responses.DtosPokeType;
using VortiDex.Dtos.Responses.DtosSkill;

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

    public ICollection<ReadPokeTypeDto> PokeTypes { get; set; }

    public ICollection<ReadSkillDto> Skills { get; set; }
}
