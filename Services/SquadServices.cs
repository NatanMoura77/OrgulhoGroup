using VortiDex.Dtos.Request.DtosSquad;
using VortiDex.Dtos.Responses.DtosSquad;
using VortiDex.Infra.Repositories;
using VortiDex.Mapper.Implementations;

namespace VortiDex.Services;

public class SquadServices
{
    private readonly SquadRepository _squadRep;
    private readonly SquadMapper _mapper;
    public SquadServices(SquadRepository squadRep, SquadMapper mapper)
    {
        _squadRep = squadRep;
        _mapper = mapper;
    }

    public void CreateServ(CreateSquadDto createDto)
    {
        var squad = _mapper
            .ToModel(createDto);

        squad = _squadRep
            .CreateRep(squad);

    }

    public void GetById(int squadId)
    {
        var squad = _squadRep
            .FindById(squadId);
        //?? throw new StudentNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(squad);
    }

    public ICollection<ReadSquadDtoWithRelations> GetAllServ()
    {
        var squad = _squadRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoWithRelationsCollection(squad);

        return dto;
    }

    public void UpdateServ(int squadId, UpdateSquadDto updateDto)
    {
        var squad = _squadRep.FindById(squadId);

        if (squad is null)
        {
            CreateServ(_mapper.ToCreateDto(updateDto));
        }
        else
        {
            squad = _mapper.ToExistentModel(updateDto, squad);
            _squadRep.UpdateRep(squad);
            _mapper.ToReadDtoWithRelations(squad);
        }
    }

    public void Delete(int squadId)
    {
        var squad = _squadRep
           .FindById(squadId);
        //?? throw new StudentNotFoundException();

        _squadRep
            .DeleteRep(squad);

        return;
    }
}
