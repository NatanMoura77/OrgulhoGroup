using VortiDex.Dtos.Request.DtosSquad;
using VortiDex.Dtos.Responses.DtosSquad;
using VortiDex.Model;

namespace VortiDex.Services.Interface
{
    public interface ISquadService : IService<Squad, CreateSquadDto, UpdateSquadDto, ReadSquadDto, ReadSquadDtoWithRelations>
    {
        ReadSquadDtoWithRelations AddPokemonToSquad(int squadId, int pokemonId);
    }
}
