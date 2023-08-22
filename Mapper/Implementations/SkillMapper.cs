using AutoMapper;
using VortiDex.Dtos.Request.DtosSkill;
using VortiDex.Dtos.Responses.DtosSkill;
using VortiDex.Mapper.Interfaces;
using VortiDex.Model;

namespace VortiDex.Mapper.Implementations;

public class SkillMapper : ISkillMapper
{
    private readonly IMapper _mapper;

    public SkillMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Skill ToModel(CreateSkillDto dto) =>
        _mapper.Map<Skill>(dto);

    public Skill ToModelUp(UpdateSkillDto dto) =>
        _mapper.Map<Skill>(dto);

    public Skill ToExistentModel(UpdateSkillDto dto, Skill skill) =>
        _mapper.Map(dto, skill);

    public CreateSkillDto ToCreateDto(UpdateSkillDto dto) =>
        _mapper.Map<CreateSkillDto>(dto);

    public ICollection<ReadSkillDto> ToReadDtoCollection(
        ICollection<Skill> skills
    ) => _mapper.Map<ICollection<ReadSkillDto>>(skills);

    public ReadSkillDtoWithRelations ToReadDtoWithRelations(Skill skill) =>
        _mapper.Map<ReadSkillDtoWithRelations>(skill);
}