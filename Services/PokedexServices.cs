using VortiDex.Dtos.Request.DtosPokedex;
using VortiDex.Dtos.Responses.DtosPokedex;
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

    public void CreateServ(CreatePokedexDto createDto)
    {
        var pokedex = _mapper
            .ToModel(createDto);

        pokedex = _pokedexRep
            .CreateRep(pokedex);

    }

    public void GetById(int pokedexId)
    {
        var pokedex = _pokedexRep
            .FindById(pokedexId);
        //?? throw new StudentNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(pokedex);
    }

    public ICollection<ReadPokedexDtoWithRelations> GetAllServ()
    {
        var pokedex = _pokedexRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoWithRelationsCollection(pokedex);

        return dto;
    }

    public void UpdateServ(int pokedexId, UpdatePokedexDto updateDto)
    {
        var pokedex = _pokedexRep.FindById(pokedexId);

        if (pokedex is null)
        {
            CreateServ(_mapper.ToCreateDto(updateDto));
        }
        else
        {
            pokedex = _mapper.ToExistentModel(updateDto, pokedex);
            _pokedexRep.UpdateRep(pokedex);
            _mapper.ToReadDtoWithRelations(pokedex);
        }
    }

    public void Delete(int pokedexId)
    {
        var pokedex = _pokedexRep
           .FindById(pokedexId);
        //?? throw new StudentNotFoundException();

        _pokedexRep
            .DeleteRep(pokedex);

        return;
    }
}
