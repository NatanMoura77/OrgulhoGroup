using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VortiDex.Model;

public class PokeType
{
    [Key]
    [Required]
    public required string Name { get; set; }

    [JsonIgnore]
    public required ICollection<Pokemon> Pokemon { get; set; }

    [JsonIgnore]
    public required ICollection<Skill> Skills { get; set; }

}
