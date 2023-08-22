using VortiDex.Dtos.Request.DtosSquad;
using VortiDex.Dtos.Responses.DtosSquad;
using VortiDex.Model;

namespace VortiDex.Mapper.Interfaces;

public interface ISquadMapper : IGeralMapper<Squad, CreateSquadDto, UpdateSquadDto, ReadSquadDto, ReadSquadDtoWithRelations>
{
}
