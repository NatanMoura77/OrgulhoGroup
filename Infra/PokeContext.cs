using Microsoft.EntityFrameworkCore;
using VortiDex.Model;

namespace VortiDex.Infra;

public class PokeContext : DbContext
{

    public DbSet<Pokedex> Pokedex { get; set; }

    public DbSet<Pokemon> Pokemon { get; set; }

    public DbSet<Skill> Skills { get; set; }

    public DbSet<Squad> Squads { get; set; }

    public DbSet<Trainer> Trainers { get; set; }

    public DbSet<PokeType> PokeTypes { get; set; }

    public PokeContext(DbContextOptions<PokeContext> options) : base(options)
    {

    }

}
