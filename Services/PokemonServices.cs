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

    public void CreateServ(CreatePokemonDto createDto)
    {
        var pokemon = _mapper
            .ToModel(createDto);

        pokemon = _pokemonRep
            .CreateRep(pokemon);

    }

    public void GetById(int pokemonId)
    {
        var pokemon = _pokemonRep
            .FindById(pokemonId);
        //?? throw new StudentNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(pokemon);
    }

    public ICollection<ReadPokemonDtoWithRelations> GetAllServ()
    {
        var pokemon = _pokemonRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoWithRelationsCollection(pokemon);

        return dto;
    }

    public void UpdateServ(int pokemonId, UpdatePokemonDto updateDto)
    {
        var pokemon = _pokemonRep.FindById(pokemonId);

        if (pokemon is null)
        {
            CreateServ(_mapper.ToCreateDto(updateDto));
        }
        else
        {
            pokemon = _mapper.ToExistentModel(updateDto, pokemon);
            _pokemonRep.UpdateRep(pokemon);
            _mapper.ToReadDtoWithRelations(pokemon);
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
}
