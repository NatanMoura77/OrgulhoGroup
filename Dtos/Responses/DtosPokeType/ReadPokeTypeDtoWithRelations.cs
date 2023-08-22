using VortiDex.Dtos.Responses.DtosPokemon;
using VortiDex.Dtos.Responses.DtosSkill;

namespace VortiDex.Dtos.Responses.DtosPokeType;

public class ReadPokeTypeDtoWithRelations
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<ReadPokemonDto> Pokemon { get; set; }
    public ICollection<ReadSkillDto> Skills { get; set; }
}
