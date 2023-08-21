using AutoMapper;
using VortiDex.Dtos.Request.DtosPokemon;
using VortiDex.Dtos.Responses.DtosPokemon;
using VortiDex.Model;

namespace VortiDex.Mapper.Implementations;

public class PokemonMapper
{
    private readonly IMapper _mapper;

    public PokemonMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Pokemon ToModel(CreatePokemonDto dto) =>
        _mapper.Map<Pokemon>(dto);

    public Pokemon ToModelUp(UpdatePokemonDto dto) =>
        _mapper.Map<Pokemon>(dto);

    public Pokemon ToExistentModel(UpdatePokemonDto dto, Pokemon pokemon) =>
        _mapper.Map(dto, pokemon);

    public CreatePokemonDto ToCreateDto(UpdatePokemonDto dto) =>
        _mapper.Map<CreatePokemonDto>(dto);

    public ReadPokemonDto ToReadDto(Pokemon pokemon) =>
        _mapper.Map<ReadPokemonDto>(pokemon);

    public ICollection<ReadPokemonDto> ToReadDtoCollection(
        ICollection<Pokemon> pokemons
    ) => _mapper.Map<ICollection<ReadPokemonDto>>(pokemons);

    public ReadPokemonDtoWithRelations ToReadDtoWithRelations(Pokemon pokemon) =>
        _mapper.Map<ReadPokemonDtoWithRelations>(pokemon);

    public ICollection<ReadPokemonDtoWithRelations> ToReadDtoWithRelationsCollection(
        ICollection<Pokemon> pokemons
    ) => _mapper.Map<ICollection<ReadPokemonDtoWithRelations>>(pokemons);
}
