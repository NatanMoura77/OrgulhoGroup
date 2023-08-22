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

    public Trainer Trainer { get; set; }

    public ICollection<Pokemon>? Pokemons { get; set; }

    public Squad()
    {
        Pokemons = new List<Pokemon>();
    }
}
