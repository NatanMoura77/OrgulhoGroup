using VortiDex.Dtos.Request.DtosPokemon;
using VortiDex.Dtos.Responses.DtosPokemon;
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

        pokemon = _pokemonRep
            .CreateRep(pokemon);

        var readPokemon = _mapper
            .ToReadDtoWithRelations(pokemon);
        
        return readPokemon;
    }

    public ReadPokemonDtoWithRelations GetById(int pokemonId)
    {
        var pokemon = _pokemonRep
            .FindById(pokemonId);
        //?? throw new StudentNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(pokemon);

        return dto;
    }

    public ICollection<ReadPokemonDtoWithRelations> GetAllServ()
    {
        var pokemon = _pokemonRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoWithRelationsCollection(pokemon);

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
           .FindById(pokemonId);
        //?? throw new StudentNotFoundException();

        _pokemonRep
            .DeleteRep(pokemon);

        return;
    }

    public ReadPokemonDtoWithRelations LearnMoveServ(int pokemonId, int skillId)
    {
        var pokemon = _pokemonRep
            .FindById(pokemonId);

        pokemon = _pokemonRep
            .LearnMoveRep(pokemon, skillId);

        var dto = _mapper
            .ToReadDtoWithRelations(pokemon);

        return dto;
    }
}
