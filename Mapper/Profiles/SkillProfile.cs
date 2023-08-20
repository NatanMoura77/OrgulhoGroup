using AutoMapper;
using VortiDex.Dtos.Request.DtosSkill;
using VortiDex.Dtos.Responses.DtosSkill;
using VortiDex.Model;

namespace VortiDex.Mapper.Profiles;

public class SkillProfile : Profile
{
    public SkillProfile()
    {
        CreateMap<CreateSkillDto, Skill>().ReverseMap();
        CreateMap<UpdateSkillDto, Skill>().ReverseMap();
        CreateMap<Skill, ReadSkillDto>();
    }
}
