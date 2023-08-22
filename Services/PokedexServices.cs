using VortiDex.Dtos.Request.DtosPokedex;
using VortiDex.Dtos.Responses.DtosPokedex;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Infra.Repositories.Interfaces;
using VortiDex.Mapper.Interfaces;
using VortiDex.Services.Interface;

namespace VortiDex.Services;

public class PokedexServices : IPokedexService
{
    private readonly IPokedexRepository _pokedexRep;
    private readonly IPokedexMapper _mapper;
    public PokedexServices(IPokedexRepository pokedexRep, IPokedexMapper mapper)
    {
        _pokedexRep = pokedexRep;
        _mapper = mapper;
    }

    public ReadPokedexDtoWithRelations Create(CreatePokedexDto createDto)
    {
        var pokedex = _mapper
            .ToModel(createDto);

        pokedex = _pokedexRep
            .CreateRep(pokedex);

        var dto = _mapper.ToReadDtoWithRelations(pokedex);

        return dto;
    }

    public ReadPokedexDtoWithRelations ReadById(int pokedexId)
    {
        var pokedex = _pokedexRep
            .FindById(pokedexId) ?? throw new PokedexNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(pokedex);

        return dto;
    }

    public ICollection<ReadPokedexDto> ReadAll()
    {
        var pokedex = _pokedexRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoCollection(pokedex);

        return dto;
    }

    public ReadPokedexDtoWithRelations Update(int pokedexId, UpdatePokedexDto updateDto)
    {
        var pokedex = _pokedexRep.FindById(pokedexId);

        if (pokedex is null)
        {
            return Create(_mapper.ToCreateDto(updateDto));
        }
        else
        {
            pokedex = _mapper.ToExistentModel(updateDto, pokedex);
            _pokedexRep.UpdateRep(pokedex);

            return _mapper.ToReadDtoWithRelations(pokedex);
        }
    }

    public void Delete(int pokedexId)
    {
        var pokedex = _pokedexRep
           .FindById(pokedexId) ?? throw new PokedexNotFoundException();

        _pokedexRep
            .DeleteRep(pokedex);

        return;
    }

    public ReadPokedexDtoWithRelations AddPokemonToPokedex(int pokedexId, int pokemonId)
    {
        var pokedex = _pokedexRep.FindById(pokedexId) ?? throw new PokedexNotFoundException();

        pokedex = _pokedexRep.AddPokemonToPokedex(pokedex, pokemonId);

        return _mapper.ToReadDtoWithRelations(pokedex);
    }
}
