using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VortiDex.Migrations
{
    /// <inheritdoc />
    public partial class poketypecollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokeTypePokemon_PokeType_PokeTypesName",
                table: "PokeTypePokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_PokeType_TypeName",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokeType",
                table: "PokeType");

            migrationBuilder.RenameTable(
                name: "PokeType",
                newName: "PokeTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokeTypes",
                table: "PokeTypes",
                column: "Name");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokeTypePokemon_PokeTypes_PokeTypesName",
                table: "PokeTypePokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_PokeTypes_TypeName",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokeTypes",
                table: "PokeTypes");

            migrationBuilder.RenameTable(
                name: "PokeTypes",
                newName: "PokeType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokeType",
                table: "PokeType",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_PokeTypePokemon_PokeType_PokeTypesName",
                table: "PokeTypePokemon",
                column: "PokeTypesName",
                principalTable: "PokeType",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_PokeType_TypeName",
                table: "Skills",
                column: "TypeName",
                principalTable: "PokeType",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
