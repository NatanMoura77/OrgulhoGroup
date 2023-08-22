using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VortiDex.Model;

public class Trainer
{

    [Key]
    [Required]
    public required int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public Pokedex Pokedex { get; set; }

    public ICollection<Squad> Squads { get; set; }

    public Trainer()
    {
        Squads = new List<Squad>();
    }
}
