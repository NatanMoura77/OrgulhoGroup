using VortiDex.Dtos.Request.DtosSkill;
using VortiDex.Dtos.Responses.DtosSkill;
using VortiDex.Infra.Repositories;
using VortiDex.Mapper.Implementations;

namespace VortiDex.Services;

public class SkillServices
{
    private readonly SkillRepository _skillRep;
    private readonly SkillMapper _mapper;
    public SkillServices(SkillRepository skillRep, SkillMapper mapper)
    {
        _skillRep = skillRep;
        _mapper = mapper;
    }

    public void CreateServ(CreateSkillDto createDto)
    {
        var skill = _mapper
            .ToModel(createDto);

        skill = _skillRep
            .CreateRep(skill);

    }

    public void GetById(int skillId)
    {
        var skill = _skillRep
            .FindById(skillId);
        //?? throw new StudentNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(skill);
    }

    public ICollection<ReadSkillDtoWithRelations> GetAllServ()
    {
        var skill = _skillRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoWithRelationsCollection(skill);

        return dto;
    }

    public void UpdateServ(int skillId, UpdateSkillDto updateDto)
    {
        var skill = _skillRep.FindById(skillId);

        if (skill is null)
        {
            CreateServ(_mapper.ToCreateDto(updateDto));
        }
        else
        {
            skill = _mapper.ToExistentModel(updateDto, skill);
            _skillRep.UpdateRep(skill);
            _mapper.ToReadDtoWithRelations(skill);
        }
    }

    public void Delete(int skillId)
    {
        var skill = _skillRep
           .FindById(skillId);
        //?? throw new StudentNotFoundException();

        _skillRep
            .DeleteRep(skill);

        return;
    }
}
