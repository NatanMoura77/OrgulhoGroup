using AutoMapper;
using VortiDex.Dtos.Request.DtosPokeType;
using VortiDex.Dtos.Responses.DtosPokeType;
using VortiDex.Model;

namespace VortiDex.Mapper.Implementations;

public class PokeTypeMapper
{
    private readonly IMapper _mapper;

    public PokeTypeMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public PokeType ToModel(CreatePokeTypeDto dto) =>
        _mapper.Map<PokeType>(dto);

    public PokeType ToModelUp(UpdatePokeTypeDto dto) =>
        _mapper.Map<PokeType>(dto);

    public PokeType ToExistentModel(UpdatePokeTypeDto dto, PokeType pokeType) =>
        _mapper.Map(dto, pokeType);

    public CreatePokeTypeDto ToCreateDto(UpdatePokeTypeDto dto) =>
        _mapper.Map<CreatePokeTypeDto>(dto);

    public ICollection<ReadPokeTypeDto> ToReadDtoCollection(
        ICollection<PokeType> pokeTypes
    ) => _mapper.Map<ICollection<ReadPokeTypeDto>>(pokeTypes);

    public ReadPokeTypeDtoWithRelations ToReadDtoWithRelations(PokeType pokeType) =>
        _mapper.Map<ReadPokeTypeDtoWithRelations>(pokeType);
}
