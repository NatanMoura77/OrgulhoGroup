using VortiDex.Dtos.Request.DtosSkill;
using VortiDex.Dtos.Responses.DtosSkill;
using VortiDex.Model;

namespace VortiDex.Mapper.Interfaces;

public interface ISkillMapper : IGeralMapper<Skill, CreateSkillDto, UpdateSkillDto, ReadSkillDto, ReadSkillDtoWithRelations>
{
}
