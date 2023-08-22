using VortiDex.Dtos.Request.DtosPokedex;
using VortiDex.Dtos.Responses.DtosPokedex;
using VortiDex.Model;

namespace VortiDex.Mapper.Interfaces;

public interface IPokedexMapper : 
    IGeralMapper<Pokedex, CreatePokedexDto, 
        UpdatePokedexDto, ReadPokedexDto, ReadPokedexDtoWithRelations>
{
}
