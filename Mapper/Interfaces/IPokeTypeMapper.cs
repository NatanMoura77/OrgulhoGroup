using VortiDex.Dtos.Request.DtosPokeType;
using VortiDex.Dtos.Responses.DtosPokeType;
using VortiDex.Model;

namespace VortiDex.Mapper.Interfaces;

public interface IPokeTypeMapper : 
    IGeralMapper<PokeType, CreatePokeTypeDto, 
        UpdatePokeTypeDto, ReadPokeTypeDto, ReadPokeTypeDtoWithRelations>
{
}
