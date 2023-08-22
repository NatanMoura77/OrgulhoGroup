using VortiDex.Dtos.Responses.DtosPokemon;
using VortiDex.Dtos.Responses.DtosSkill;

namespace VortiDex.Dtos.Responses.DtosPokeType;

public class ReadPokeTypeDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
}