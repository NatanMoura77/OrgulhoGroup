using VortiDex.Model;

namespace VortiDex.Dtos.Request.DtosSkill;

public class UpdateSkillDto
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public required int PokeTypeId { get; set; }
}
