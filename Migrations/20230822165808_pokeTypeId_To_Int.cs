using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VortiDex.Migrations
{
    /// <inheritdoc />
    public partial class pokeTypeId_To_Int : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokeTypePokemon_PokeTypes_PokeTypesName",
                table: "PokeTypePokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_PokeTypes_TypeName",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_TypeName",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokeTypes",
                table: "PokeTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokeTypePokemon",
                table: "PokeTypePokemon");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "PokeTypesName",
                table: "PokeTypePokemon");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PokeTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PokeTypes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PokeTypesId",
                table: "PokeTypePokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokeTypes",
                table: "PokeTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokeTypePokemon",
                table: "PokeTypePokemon",
                columns: new[] { "PokeTypesId", "PokemonId" });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_TypeId",
                table: "Skills",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokeTypePokemon_PokeTypes_PokeTypesId",
                table: "PokeTypePokemon",
                column: "PokeTypesId",
                principalTable: "PokeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_PokeTypes_TypeId",
                table: "Skills",
                column: "TypeId",
                principalTable: "PokeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokeTypePokemon_PokeTypes_PokeTypesId",
                table: "PokeTypePokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_PokeTypes_TypeId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_TypeId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokeTypes",
                table: "PokeTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokeTypePokemon",
                table: "PokeTypePokemon");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PokeTypes");

            migrationBuilder.DropColumn(
                name: "PokeTypesId",
                table: "PokeTypePokemon");

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "Skills",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PokeTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PokeTypesName",
                table: "PokeTypePokemon",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokeTypes",
                table: "PokeTypes",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokeTypePokemon",
                table: "PokeTypePokemon",
                columns: new[] { "PokeTypesName", "PokemonId" });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_TypeName",
                table: "Skills",
                column: "TypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_PokeTypePokemon_PokeTypes_PokeTypesName",
                table: "PokeTypePokemon",
                column: "PokeTypesName",
                principalTable: "PokeTypes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_PokeTypes_TypeName",
                table: "Skills",
                column: "TypeName",
                principalTable: "PokeTypes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
