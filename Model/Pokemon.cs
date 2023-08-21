using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VortiDex.Model;

public class Pokemon
{
    [Key]
    [Required]
    public required int Id { get; set; }

    [Required] 
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required double Height { get; set; }

    [Required]
    public required double Weight { get; set; }

    [Required]
    public required bool IsCatch { get; set; }

    [Required]
    public required string Picture { get; set; }

    [Required]
    public ICollection<PokeType> PokeTypes { get; set; }

    [NotMapped]
    public ICollection<string> PokeTypesId { get; set; }

    public ICollection<Squad>? Squads { get; set; }

    public ICollection<Skill> Skills { get; set; }

    public Pokemon()
    {
        Squads = new List<Squad>();
        Skills = new List<Skill>();
        PokeTypes = new List<PokeType>();
        PokeTypesId = new List<string>();
    }
}
