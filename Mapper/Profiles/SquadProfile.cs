using AutoMapper;
using VortiDex.Dtos.Request.DtosSquad;
using VortiDex.Dtos.Responses.DtosSquad;
using VortiDex.Model;

namespace VortiDex.Mapper.Profiles;

public class SquadProfile : Profile
{
    public SquadProfile()
    {
        CreateMap<CreateSquadDto, Squad>().ReverseMap();
        CreateMap<UpdateSquadDto, Squad>().ReverseMap();
        CreateMap<Squad, ReadSquadDto>();
        CreateMap<UpdateSquadDto, CreateSquadDto>();

        CreateMap<Squad, ReadSquadDtoWithRelations>()
            .ForMember(
                dest => dest.Pokemons,
                opt => opt.MapFrom(src => src.Pokemons));
    }
}
