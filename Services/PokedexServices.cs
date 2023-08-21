using VortiDex.Dtos.Request.DtosPokedex;
using VortiDex.Dtos.Responses.DtosPokedex;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Infra.Repositories;
using VortiDex.Mapper.Implementations;

namespace VortiDex.Services;

public class PokedexServices
{
    private readonly PokedexRepository _pokedexRep;
    private readonly PokedexMapper _mapper;
    public PokedexServices(PokedexRepository pokedexRep, PokedexMapper mapper)
    {
        _pokedexRep = pokedexRep;
        _mapper = mapper;
    }

    public ReadPokedexDtoWithRelations CreateServ(CreatePokedexDto createDto)
    {
        var pokedex = _mapper
            .ToModel(createDto);

        pokedex = _pokedexRep
            .CreateRep(pokedex);

        var dto = _mapper.ToReadDtoWithRelations(pokedex);

        return dto;
    }

    public ReadPokedexDtoWithRelations GetById(int pokedexId)
    {
        var pokedex = _pokedexRep
            .FindById(pokedexId) ?? throw new PokedexNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(pokedex);

        return dto;
    }

    public ICollection<ReadPokedexDto> GetAllServ()
    {
        var pokedex = _pokedexRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoCollection(pokedex);

        return dto;
    }

    public ReadPokedexDtoWithRelations UpdateServ(int pokedexId, UpdatePokedexDto updateDto)
    {
        var pokedex = _pokedexRep.FindById(pokedexId);

        if (pokedex is null)
        {
            return CreateServ(_mapper.ToCreateDto(updateDto));
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
