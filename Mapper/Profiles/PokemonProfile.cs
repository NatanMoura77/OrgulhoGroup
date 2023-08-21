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

        CreateMap<Pokemon, ReadPokemonDtoWithRelations>();
    }
}
