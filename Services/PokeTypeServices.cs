using VortiDex.Dtos.Request.DtosPokeType;
using VortiDex.Dtos.Responses.DtosPokeType;
using VortiDex.Infra.Repositories;
using VortiDex.Mapper.Implementations;

namespace VortiDex.Services;

public class PokeTypeServices
{
    private readonly PokeTypeRepository _pokeTypeRep;
    private readonly PokeTypeMapper _mapper;
    public PokeTypeServices(PokeTypeRepository pokeTypeRep, PokeTypeMapper mapper)
    {
        _pokeTypeRep = pokeTypeRep;
        _mapper = mapper;
    }

    public void CreateServ(CreatePokeTypeDto createDto)
    {
        var pokeType = _mapper
            .ToModel(createDto);

        pokeType = _pokeTypeRep
            .CreateRep(pokeType);

    }

    public void GetById(string pokeTypeId)
    {
        var pokeType = _pokeTypeRep
            .FindById(pokeTypeId);
        //?? throw new StudentNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(pokeType);
    }

    public ICollection<ReadPokeTypeDtoWithRelations> GetAllServ()
    {
        var pokeType = _pokeTypeRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoCollection(pokeType);

        return dto;
    }

    public void UpdateServ(string pokeTypeId, UpdatePokeTypeDto updateDto)
    {
        var pokeType = _pokeTypeRep.FindById(pokeTypeId);

        if (pokeType is null)
        {
            CreateServ(_mapper.ToCreateDto(updateDto));
        }
        else
        {
            pokeType = _mapper.ToExistentModel(updateDto, pokeType);
            _pokeTypeRep.UpdateRep(pokeType);
            _mapper.ToReadDtoWithRelations(pokeType);
        }
    }

    public void Delete(string pokeTypeId)
    {
        var pokeType = _pokeTypeRep
           .FindById(pokeTypeId);
        //?? throw new StudentNotFoundException();

        _pokeTypeRep
            .DeleteRep(pokeType);

        return;
    }
}
