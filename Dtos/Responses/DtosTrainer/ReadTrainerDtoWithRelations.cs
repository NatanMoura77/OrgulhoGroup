using VortiDex.Model;

namespace VortiDex.Dtos.Responses.DtosTrainer;

public class ReadTrainerDtoWithRelations
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required ICollection<Squad> Squads { get; set; }
}

