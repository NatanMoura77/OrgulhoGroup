using VortiDex.Dtos.Request.DtosPokemon;
using VortiDex.Dtos.Responses.DtosPokemon;
using VortiDex.Exceptions.BadRequestExceptions;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Infra.Repositories.Interfaces;
using VortiDex.Mapper.Interfaces;
using VortiDex.Services.Interface;

namespace VortiDex.Services;

public class PokemonServices : IPokemonService
{
    private readonly IPokemonRepository _pokemonRep;
    private readonly IPokemonMapper _mapper;
    public PokemonServices(IPokemonRepository pokemonRep, IPokemonMapper mapper)
    {
        _pokemonRep = pokemonRep;
        _mapper = mapper;
    }

    public ReadPokemonDtoWithRelations Create(CreatePokemonDto createDto)
    {
        createDto.Name = createDto.Name.ToUpper();

        if (createDto.PokeTypesId.Count > 2)
            throw new BadRequestException("Um Pokemon só pode ter dois tipos!");
        
        var pokemon = _mapper
            .ToModel(createDto);

        pokemon = _pokemonRep
            .CreateRep(pokemon);

        var readPokemon = _mapper
            .ToReadDtoWithRelations(pokemon);

        return readPokemon;
    }

    public ReadPokemonDtoWithRelations ReadById(int pokemonId)
    {
        var pokemon = _pokemonRep
            .FindById(pokemonId) ?? throw new PokemonNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(pokemon);

        return dto;
    }

    public ICollection<ReadPokemonDto> ReadAll()
    {
        var pokemon = _pokemonRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoCollection(pokemon);

        return dto;
    }

    public ReadPokemonDtoWithRelations Update(int pokemonId, UpdatePokemonDto updateDto)
    {
        var pokemon = _pokemonRep.FindById(pokemonId);

        if (pokemon is null)
            return Create(_mapper.ToCreateDto(updateDto));

        if (updateDto.PokeTypesId.Count > 2)
            throw new BadRequestException("Um Pokemon só pode ter dois tipos!");
        
        if (updateDto.PokeTypesId.First().Equals(updateDto.PokeTypesId.Last()) && updateDto.PokeTypesId.Count > 1)
            throw new BadRequestException("Um pokemon não pode ter dois tipos iguais!");

        pokemon = _mapper.ToExistentModel(updateDto, pokemon);

        _pokemonRep.UpdateRep(pokemon);

        var dto = _mapper.ToReadDtoWithRelations(pokemon);

        return dto;
    }

    public void Delete(int pokemonId)
    {
        var pokemon = _pokemonRep
           .FindById(pokemonId) ?? throw new PokemonNotFoundException();

        _pokemonRep
            .DeleteRep(pokemon);

        return;
    }

    public ReadPokemonDtoWithRelations LearnMoveServ(int pokemonId, int skillId)
    {

        var pokemon = _pokemonRep
            .FindById(pokemonId) ?? throw new PokemonNotFoundException();

        if (pokemon.Skills.FirstOrDefault(skill => skill.Id == skillId) != null)
        {
            throw new BadRequestException("O pokemon já possui essa habilidade!");
        }

        if (pokemon.Skills.Count >= 4)
        {
            throw new BadRequestException("O pokemon já possui 4 habilidades!");
        }

        pokemon = _pokemonRep
            .LearnMoveRep(pokemon, skillId);


        var dto = _mapper
            .ToReadDtoWithRelations(pokemon);

        return dto;
    }
}
