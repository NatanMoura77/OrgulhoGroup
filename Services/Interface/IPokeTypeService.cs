using VortiDex.Dtos.Request.DtosPokeType;
using VortiDex.Dtos.Responses.DtosPokeType;
using VortiDex.Model;

namespace VortiDex.Services.Interface
{
    public interface IPokeTypeService : 
        IService<PokeType, CreatePokeTypeDto, UpdatePokeTypeDto, ReadPokeTypeDto, ReadPokeTypeDtoWithRelations>
    {
    }
}
