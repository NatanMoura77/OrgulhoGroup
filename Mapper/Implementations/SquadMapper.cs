using AutoMapper;
using VortiDex.Dtos.Request.DtosSquad;
using VortiDex.Dtos.Responses.DtosSquad;
using VortiDex.Model;

namespace VortiDex.Mapper.Implementations;

public class SquadMapper
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

    public ReadSquadDto ToReadDto(Squad squad) =>
        _mapper.Map<ReadSquadDto>(squad);

    public ICollection<ReadSquadDto> ToReadDtoCollection(
        ICollection<Squad> squads
    ) => _mapper.Map<ICollection<ReadSquadDto>>(squads);

    public ReadSquadDto ToReadDtoWithRelations(Squad squad) =>
        _mapper.Map<ReadSquadDto>(squad);

    public ICollection<ReadSquadDtoWithRelations> ToReadDtoWithRelationsCollection(
        ICollection<Squad> squads
    ) => _mapper.Map<ICollection<ReadSquadDtoWithRelations>>(squads);
}
