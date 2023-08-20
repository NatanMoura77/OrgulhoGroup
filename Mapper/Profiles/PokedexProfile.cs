using AutoMapper;
using VortiDex.Dtos.Request.DtosPokedex;
using VortiDex.Dtos.Responses.DtosPokedex;
using VortiDex.Model;

namespace VortiDex.Mapper.Profiles;

public class PokedexProfile : Profile
{
    public PokedexProfile()
    {
        CreateMap<CreatePokedexDto, Pokedex>().ReverseMap();
        CreateMap<UpdatePokedexDto, Pokedex>().ReverseMap();
        CreateMap<Pokedex, ReadPokedexDto>();
        CreateMap<UpdatePokedexDto, CreatePokedexDto>();

        CreateMap<Pokedex, ReadPokedexDtoWithRelations>()
            .ForMember(
                dest => dest.Pokemons,
                opt => opt.MapFrom(src => src.Pokemons));
    }
}
