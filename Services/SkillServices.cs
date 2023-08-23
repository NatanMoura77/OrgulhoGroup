using VortiDex.Dtos.Request.DtosSkill;
using VortiDex.Dtos.Responses.DtosSkill;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Infra.Repositories.Interfaces;
using VortiDex.Mapper.Interfaces;
using VortiDex.Services.Interface;

namespace VortiDex.Services;

public class SkillServices : ISkillService
{
    private readonly ISkillRepository _skillRep;
    private readonly ISkillMapper _mapper;
    public SkillServices(ISkillRepository skillRep, ISkillMapper mapper)
    {
        _skillRep = skillRep;
        _mapper = mapper;
    }

    public ReadSkillDtoWithRelations Create(CreateSkillDto createDto)
    {
        createDto.Name = createDto.Name.ToUpper();

        var skill = _mapper
            .ToModel(createDto);

        _skillRep
            .CreateRep(skill);

        var readSkill = _mapper
            .ToReadDtoWithRelations(skill);

        return (readSkill);
    }

    public ReadSkillDtoWithRelations ReadById(int skillId)
    {
        var skill = _skillRep
            .FindById(skillId) ?? throw new SkillNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(skill);

        return (dto);
    }

    public ICollection<ReadSkillDto> ReadAll()
    {
        var skill = _skillRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoCollection(skill);

        return dto;
    }

    public ReadSkillDtoWithRelations Update(int skillId, UpdateSkillDto updateDto)
    {
        var skill = _skillRep
            .FindById(skillId);

        if (skill is null)
            return Create(
                _mapper
                    .ToCreateDto(updateDto)
            );

        skill.Name = skill.Name.ToUpper();

        skill = _mapper
            .ToExistentModel(updateDto, skill);

        _skillRep
            .UpdateRep(skill);

        var skillDto = _mapper
            .ToReadDtoWithRelations(skill);

        return skillDto;
    }

    public void Delete(int skillId)
    {
        var skill = _skillRep
           .FindById(skillId) ?? throw new SkillNotFoundException();

        _skillRep
            .DeleteRep(skill);

        return;
    }
}
