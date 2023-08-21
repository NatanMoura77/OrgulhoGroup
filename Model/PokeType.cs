using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VortiDex.Model;

public class PokeType
{
    [Key]
    [Required]
    public required string Name { get; set; }

    [JsonIgnore]
    public ICollection<Pokemon>? Pokemon { get; set; }

    [JsonIgnore]
    public ICollection<Skill>? Skills { get; set; }

}
