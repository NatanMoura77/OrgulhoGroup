using VortiDex.Dtos.Request.DtosPokemon;
using VortiDex.Dtos.Responses.DtosPokemon;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Infra.Repositories;
using VortiDex.Mapper.Implementations;

namespace VortiDex.Services;

public class PokemonServices
{
    private readonly PokemonRepository _pokemonRep;
    private readonly PokemonMapper _mapper;
    public PokemonServices(PokemonRepository pokemonRep, PokemonMapper mapper)
    {
        _pokemonRep = pokemonRep;
        _mapper = mapper;
    }

    public ReadPokemonDtoWithRelations CreateServ(CreatePokemonDto createDto)
    {
        var pokemon = _mapper
            .ToModel(createDto);

        if (pokemon.PokeTypesId.Count > 2)
        {
            throw new BadHttpRequestException("A pokemon can only have 2 types");
        }

        pokemon = _pokemonRep
            .CreateRep(pokemon);

        var readPokemon = _mapper
            .ToReadDtoWithRelations(pokemon);
        
        return readPokemon;
    }

    public ReadPokemonDtoWithRelations GetById(int pokemonId)
    {
        var pokemon = _pokemonRep
            .FindById(pokemonId) ?? throw new PokemonNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(pokemon);

        return dto;
    }

    public ICollection<ReadPokemonDto> GetAllServ()
    {
        var pokemon = _pokemonRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoCollection(pokemon);

        return dto;
    }

    public ReadPokemonDtoWithRelations UpdateServ(int pokemonId, UpdatePokemonDto updateDto)
    {
        var pokemon = _pokemonRep.FindById(pokemonId);

        if (pokemon is null)
        {
            return CreateServ(_mapper.ToCreateDto(updateDto));
        }
        else
        {
            pokemon = _mapper.ToExistentModel(updateDto, pokemon);
            _pokemonRep.UpdateRep(pokemon);
            var dto = _mapper.ToReadDtoWithRelations(pokemon);

            return dto;
        }
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

        pokemon = _pokemonRep
            .LearnMoveRep(pokemon, skillId);

        var dto = _mapper
            .ToReadDtoWithRelations(pokemon);

        return dto;
    }
}
