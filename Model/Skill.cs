using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    public PokeType Type { get; set; }

    [NotMapped]
    public int PokeTypeId { get; set; }

    public ICollection<Pokemon>? Pokemons { get; set; }

    public Skill()
    {
        Pokemons = new List<Pokemon>();
    }
}
