using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VortiDex.Model;

public class Skill
{
    [Key]
    [Required] 
    public required int Id { get; set; }

    [Required] 
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    [JsonIgnore]
    public required PokeType Type { get; set; }

    [JsonIgnore]
    public required ICollection<Pokemon> Pokemons { get; set; }

    public Skill()
    {
        Pokemons = new List<Pokemon>();
    }
}
