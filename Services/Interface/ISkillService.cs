using VortiDex.Dtos.Request.DtosSkill;
using VortiDex.Dtos.Responses.DtosSkill;
using VortiDex.Model;

namespace VortiDex.Services.Interface;

public interface ISkillService : IService<Skill, CreateSkillDto, UpdateSkillDto, ReadSkillDto, ReadSkillDtoWithRelations>
{
}
