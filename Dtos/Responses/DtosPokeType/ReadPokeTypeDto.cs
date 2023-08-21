using System.Text.Json.Serialization;
using VortiDex.Model;

namespace VortiDex.Dtos.Responses.DtosPokeType;

public class ReadPokeTypeDtoWithRelations
{
    public required string Name { get; set; }
    public ICollection<Pokemon> Pokemon { get; set; }
    public ICollection<Skill> Skills { get; set; }
}
