using AutoMapper;
using VortiDex.Dtos.Request.DtosSquad;
using VortiDex.Dtos.Responses.DtosSquad;
using VortiDex.Mapper.Interfaces;
using VortiDex.Model;

namespace VortiDex.Mapper.Implementations;

public class SquadMapper : ISquadMapper
{
    private readonly IMapper _mapper;

    public SquadMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Squad ToModel(CreateSquadDto dto) =>
        _mapper.Map<Squad>(dto);

    public Squad ToModelUp(UpdateSquadDto dto) =>
        _mapper.Map<Squad>(dto);

    public Squad ToExistentModel(UpdateSquadDto dto, Squad squad) =>
        _mapper.Map(dto, squad);

    public CreateSquadDto ToCreateDto(UpdateSquadDto dto) =>
        _mapper.Map<CreateSquadDto>(dto);

    public ICollection<ReadSquadDto> ToReadDtoCollection(
        ICollection<Squad> squads
    ) => _mapper.Map<ICollection<ReadSquadDto>>(squads);

    public ReadSquadDtoWithRelations ToReadDtoWithRelations(Squad squad) =>
        _mapper.Map<ReadSquadDtoWithRelations>(squad);
}