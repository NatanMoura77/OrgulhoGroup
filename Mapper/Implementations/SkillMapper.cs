using AutoMapper;
using VortiDex.Dtos.Request.DtosSkill;
using VortiDex.Dtos.Responses.DtosSkill;
using VortiDex.Model;

namespace VortiDex.Mapper.Implementations;

public class SkillMapper
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

    public ReadSkillDto ToReadDto(Skill skill) =>
        _mapper.Map<ReadSkillDto>(skill);

    public ICollection<ReadSkillDto> ToReadDtoCollection(
        ICollection<Skill> skills
    ) => _mapper.Map<ICollection<ReadSkillDto>>(skills);

    public ReadSkillDto ToReadDtoWithRelations(Skill skill) =>
        _mapper.Map<ReadSkillDto>(skill);

    public ICollection<ReadSkillDtoWithRelations> ToReadDtoWithRelationsCollection(
        ICollection<Skill> skills
    ) => _mapper.Map<ICollection<ReadSkillDtoWithRelations>>(skills);
}
