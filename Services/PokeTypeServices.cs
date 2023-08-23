using Microsoft.AspNetCore.Http.HttpResults;
using VortiDex.Dtos.Request.DtosPokeType;
using VortiDex.Dtos.Responses.DtosPokeType;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Infra.Repositories.Interfaces;
using VortiDex.Mapper.Interfaces;
using VortiDex.Services.Interface;

namespace VortiDex.Services;

public class PokeTypeServices : IPokeTypeService
{
    private readonly IPokeTypeRepository _pokeTypeRep;
    private readonly IPokeTypeMapper _mapper;
    public PokeTypeServices(IPokeTypeRepository pokeTypeRep, IPokeTypeMapper mapper)
    {
        _pokeTypeRep = pokeTypeRep;
        _mapper = mapper;
    }

    public ReadPokeTypeDtoWithRelations Create(CreatePokeTypeDto createDto)
    {
        createDto.Name = createDto.Name.ToUpper();

        var pokeType = _mapper
            .ToModel(createDto);

        pokeType = _pokeTypeRep
            .CreateRep(pokeType);

        var readPokeType = _mapper
            .ToReadDtoWithRelations(pokeType);

        return readPokeType;
    }

    public ReadPokeTypeDtoWithRelations ReadById(int pokeTypeId)
    {
        var pokeType = _pokeTypeRep
            .FindById(pokeTypeId) ?? throw new PokeTypeNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(pokeType);

        return dto;
    }

    public ICollection<ReadPokeTypeDto> ReadAll()
    {
        var pokeType = _pokeTypeRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoCollection(pokeType);

        return dto;
    }

    public ReadPokeTypeDtoWithRelations Update(int pokeTypeId, UpdatePokeTypeDto updateDto)
    {
        var pokeType = _pokeTypeRep
            .FindById(pokeTypeId);

        updateDto.Name = updateDto.Name.ToUpper();

        if (pokeType == null)
        {
            return Create(_mapper.ToCreateDto(updateDto));
        }

        pokeType = 
            _mapper.ToExistentModel(updateDto, pokeType);

        _pokeTypeRep
            .UpdateRep(pokeType);

        var pokeTypeDto = _mapper
            .ToReadDtoWithRelations(pokeType);

        return pokeTypeDto;
    }

    public void Delete(int pokeTypeId)
    {
        var pokeType = _pokeTypeRep
           .FindById(pokeTypeId) ?? throw new PokeTypeNotFoundException();

        _pokeTypeRep
            .DeleteRep(pokeType);

        return;
    }
}
