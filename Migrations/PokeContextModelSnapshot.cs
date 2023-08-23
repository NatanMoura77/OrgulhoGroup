﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VortiDex.Infra;

#nullable disable

namespace VortiDex.Migrations
{
    [DbContext(typeof(PokeContext))]
    partial class PokeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PokeTypePokemon", b =>
                {
                    b.Property<int>("PokeTypesId")
                        .HasColumnType("int");

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.HasKey("PokeTypesId", "PokemonId");

                    b.HasIndex("PokemonId");

                    b.ToTable("PokeTypePokemon");
                });

            modelBuilder.Entity("PokemonSkill", b =>
                {
                    b.Property<int>("PokemonsId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("PokemonsId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("PokemonSkill");
                });

            modelBuilder.Entity("PokemonSquad", b =>
                {
                    b.Property<int>("PokemonsId")
                        .HasColumnType("int");

                    b.Property<int>("SquadsId")
                        .HasColumnType("int");

                    b.HasKey("PokemonsId", "SquadsId");

                    b.HasIndex("SquadsId");

                    b.ToTable("PokemonSquad");
                });

            modelBuilder.Entity("VortiDex.Model.PokeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PokeTypes");
                });

            modelBuilder.Entity("VortiDex.Model.Pokedex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId")
                        .IsUnique();

                    b.ToTable("Pokedex");
                });

            modelBuilder.Entity("VortiDex.Model.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<double>("Height")
                        .HasColumnType("double");

                    b.Property<bool>("IsCatch")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("PokedexId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("PokedexId");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("VortiDex.Model.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("VortiDex.Model.Squad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.ToTable("Squads");
                });

            modelBuilder.Entity("VortiDex.Model.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("PokeTypePokemon", b =>
                {
                    b.HasOne("VortiDex.Model.PokeType", null)
                        .WithMany()
                        .HasForeignKey("PokeTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VortiDex.Model.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonSkill", b =>
                {
                    b.HasOne("VortiDex.Model.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VortiDex.Model.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonSquad", b =>
                {
                    b.HasOne("VortiDex.Model.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VortiDex.Model.Squad", null)
                        .WithMany()
                        .HasForeignKey("SquadsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VortiDex.Model.Pokedex", b =>
                {
                    b.HasOne("VortiDex.Model.Trainer", "Trainer")
                        .WithOne("Pokedex")
                        .HasForeignKey("VortiDex.Model.Pokedex", "TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("VortiDex.Model.Pokemon", b =>
                {
                    b.HasOne("VortiDex.Model.Pokedex", null)
                        .WithMany("Pokemons")
                        .HasForeignKey("PokedexId");
                });

            modelBuilder.Entity("VortiDex.Model.Skill", b =>
                {
                    b.HasOne("VortiDex.Model.PokeType", "Type")
                        .WithMany("Skills")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("VortiDex.Model.Squad", b =>
                {
                    b.HasOne("VortiDex.Model.Trainer", "Trainer")
                        .WithMany("Squads")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("VortiDex.Model.PokeType", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("VortiDex.Model.Pokedex", b =>
                {
                    b.Navigation("Pokemons");
                });

            modelBuilder.Entity("VortiDex.Model.Trainer", b =>
                {
                    b.Navigation("Pokedex")
                        .IsRequired();

                    b.Navigation("Squads");
                });
#pragma warning restore 612, 618
        }
    }
}
