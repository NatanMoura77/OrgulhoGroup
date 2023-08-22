using AutoMapper;
using VortiDex.Dtos.Request.DtosPokedex;
using VortiDex.Dtos.Responses.DtosPokedex;
using VortiDex.Mapper.Interfaces;
using VortiDex.Model;

namespace VortiDex.Mapper.Implementations;

public class PokedexMapper : IPokedexMapper
{
    private readonly IMapper _mapper;

    public PokedexMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Pokedex ToModel(CreatePokedexDto dto) =>
        _mapper.Map<Pokedex>(dto);

    public Pokedex ToModelUp(UpdatePokedexDto dto) =>
        _mapper.Map<Pokedex>(dto);

    public Pokedex ToExistentModel(UpdatePokedexDto dto, Pokedex pokedex) =>
        _mapper.Map(dto, pokedex);

    public CreatePokedexDto ToCreateDto(UpdatePokedexDto dto) =>
        _mapper.Map<CreatePokedexDto>(dto);

    public ReadPokedexDtoWithRelations ToReadDtoWithRelations(Pokedex pokedex) =>
        _mapper.Map<ReadPokedexDtoWithRelations>(pokedex);

    public ICollection<ReadPokedexDto> ToReadDtoCollection(
        ICollection<Pokedex> pokedexs
    ) => _mapper.Map<ICollection<ReadPokedexDto>>(pokedexs);
}
