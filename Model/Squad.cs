using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VortiDex.Model;

public class Squad
{

    [Key]
    [Required]
    public required int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required int TrainerId { get; set; }

    [JsonIgnore]
    public required Trainer Trainer { get; set; }

    [JsonIgnore]
    public required ICollection<Pokemon> Pokemons { get; set; }

    public Squad()
    {
        Pokemons = new List<Pokemon>();
    }
}
