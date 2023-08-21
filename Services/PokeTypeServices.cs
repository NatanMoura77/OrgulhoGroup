using VortiDex.Dtos.Request.DtosPokeType;
using VortiDex.Dtos.Responses.DtosPokeType;
using VortiDex.Exceptions.NotFoundExceptions;
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

    public ReadPokeTypeDtoWithRelations CreateServ(CreatePokeTypeDto createDto)
    {
        var pokeType = _mapper
            .ToModel(createDto);

        pokeType = _pokeTypeRep
            .CreateRep(pokeType);

        var readPokeType = _mapper
            .ToReadDtoWithRelations(pokeType);

        return readPokeType;

    }

    public ReadPokeTypeDtoWithRelations GetById(string pokeTypeId)
    {
        var pokeType = _pokeTypeRep
            .FindById(pokeTypeId) ?? throw new PokeTypeNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(pokeType);

        return dto;
    }

    public ICollection<ReadPokeTypeDto> GetAllServ()
    {
        var pokeType = _pokeTypeRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoCollection(pokeType);

        return dto;
    }

    public ReadPokeTypeDtoWithRelations UpdateServ(string pokeTypeId, UpdatePokeTypeDto updateDto)
    {
        var pokeType = _pokeTypeRep.FindById(pokeTypeId);

        if (pokeType is null)
        {
            return CreateServ(_mapper.ToCreateDto(updateDto));
        }
        else
        {
            pokeType = _mapper.ToExistentModel(updateDto, pokeType);
            _pokeTypeRep.UpdateRep(pokeType);

            return _mapper.ToReadDtoWithRelations(pokeType);
        }
    }

    public void Delete(string pokeTypeId)
    {
        var pokeType = _pokeTypeRep
           .FindById(pokeTypeId) ?? throw new PokeTypeNotFoundException();

        _pokeTypeRep
            .DeleteRep(pokeType);

        return;
    }
}
