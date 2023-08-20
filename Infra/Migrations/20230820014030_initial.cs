using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VortiDex.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokeType",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokeType", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_PokeType_TypeName",
                        column: x => x.TypeName,
                        principalTable: "PokeType",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pokedex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokedex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokedex_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Squads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Squads_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    IsCatch = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokedexId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemon_Pokedex_PokedexId",
                        column: x => x.PokedexId,
                        principalTable: "Pokedex",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PokemonSkill",
                columns: table => new
                {
                    PokemonsId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonSkill", x => new { x.PokemonsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_PokemonSkill_Pokemon_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonSquad",
                columns: table => new
                {
                    PokemonsId = table.Column<int>(type: "int", nullable: false),
                    SquadsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonSquad", x => new { x.PokemonsId, x.SquadsId });
                    table.ForeignKey(
                        name: "FK_PokemonSquad_Pokemon_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonSquad_Squads_SquadsId",
                        column: x => x.SquadsId,
                        principalTable: "Squads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokeTypePokemon",
                columns: table => new
                {
                    PokeTypesName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PokemonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokeTypePokemon", x => new { x.PokeTypesName, x.PokemonId });
                    table.ForeignKey(
                        name: "FK_PokeTypePokemon_PokeType_PokeTypesName",
                        column: x => x.PokeTypesName,
                        principalTable: "PokeType",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokeTypePokemon_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokedex_TrainerId",
                table: "Pokedex",
                column: "TrainerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_PokedexId",
                table: "Pokemon",
                column: "PokedexId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonSkill_SkillsId",
                table: "PokemonSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonSquad_SquadsId",
                table: "PokemonSquad",
                column: "SquadsId");

            migrationBuilder.CreateIndex(
                name: "IX_PokeTypePokemon_PokemonId",
                table: "PokeTypePokemon",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_TypeName",
                table: "Skills",
                column: "TypeName");

            migrationBuilder.CreateIndex(
                name: "IX_Squads_TrainerId",
                table: "Squads",
                column: "TrainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonSkill");

            migrationBuilder.DropTable(
                name: "PokemonSquad");

            migrationBuilder.DropTable(
                name: "PokeTypePokemon");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Squads");

            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "PokeType");

            migrationBuilder.DropTable(
                name: "Pokedex");

            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
