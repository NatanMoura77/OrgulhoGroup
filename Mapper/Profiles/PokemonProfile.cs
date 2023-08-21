using AutoMapper;
using VortiDex.Dtos.Request.DtosPokemon;
using VortiDex.Dtos.Responses.DtosPokemon;
using VortiDex.Model;

namespace VortiDex.Mapper.Profiles;

public class PokemonProfile : Profile
{
    public PokemonProfile()
    {
        CreateMap<CreatePokemonDto, Pokemon>().ReverseMap();
        CreateMap<UpdatePokemonDto, Pokemon>().ReverseMap();
        CreateMap<Pokemon, ReadPokemonDto>();
        CreateMap<UpdatePokemonDto, CreatePokemonDto>();

        CreateMap<Pokemon, ReadPokemonDtoWithRelations>()
            .ForMember(dest => dest.PokeTypes, opt => opt.MapFrom(src => src.PokeTypes))
            .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills)).ReverseMap();
    }
}