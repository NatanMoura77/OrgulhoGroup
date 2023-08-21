using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VortiDex.Model;

public class Pokedex
{
    [Key]
    [Required]
    public required int Id { get; set; }

    [Required]
    public required int TrainerId { get; set; }

    public Trainer Trainer { get; set; }

    public ICollection<Pokemon> Pokemons { get; set; }

    public Pokedex()
    {
        Pokemons = new List<Pokemon>();
    }
}
