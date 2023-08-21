using VortiDex.Dtos.Responses.DtosSquad;

namespace VortiDex.Dtos.Responses.DtosTrainer;

public class ReadTrainerDtoWithRelations
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required ICollection<ReadSquadDto> Squads { get; set; }
}