using AutoMapper;
using VortiDex.Dtos.Request.DtosPokeType;
using VortiDex.Dtos.Responses.DtosPokeType;
using VortiDex.Model;

namespace VortiDex.Mapper.Profiles;

public class PokeTypeProfile : Profile
{
    public PokeTypeProfile()
    {
        CreateMap<CreatePokeTypeDto, PokeType>().ReverseMap();
        CreateMap<UpdatePokeTypeDto, PokeType>().ReverseMap();

        CreateMap<PokeType, ReadPokeTypeDto>();
        CreateMap<PokeType, ReadPokeTypeDtoWithRelations>();
    }
}
