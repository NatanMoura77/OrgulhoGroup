using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
    [JsonIgnore]
    public required PokeType[] PokeTypes { get; set; } = new PokeType[2];

    [JsonIgnore]
    public required ICollection<Squad> Squads { get; set; }

    [JsonIgnore]
    public required ICollection<Skill> Skills { get; set; }

    public Pokemon()
    {
        Squads = new List<Squad>();
        Skills = new List<Skill>();
    }
}
