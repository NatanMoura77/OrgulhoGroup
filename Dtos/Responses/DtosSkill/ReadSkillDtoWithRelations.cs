using VortiDex.Dtos.Responses.DtosPokeType;

namespace VortiDex.Dtos.Responses.DtosSkill;

public class ReadSkillDtoWithRelations
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required ReadPokeTypeDto Type { get; set; }
}
