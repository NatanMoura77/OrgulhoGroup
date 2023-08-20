﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VortiDex.Model;

public class Pokedex
{
    [Key]
    [Required]
    public required int Id { get; set; }

    [Required]
    public required int TrainerId { get; set; }

    [JsonIgnore]
    public Trainer Trainer { get; set; }

    [JsonIgnore]
    public ICollection<Pokemon> Pokemons { get; set; }

    public Pokedex()
    {
        Pokemons = new List<Pokemon>();
    }
}
