using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroductionEFCore.DBLib.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElementPokemon",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementPokemon", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesPokemon",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesPokemon", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "ElementPokemonSpeciesPokemon",
                columns: table => new
                {
                    ElementPokemonsIdentifier = table.Column<int>(type: "int", nullable: false),
                    SpeciesPokemonsIdentifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementPokemonSpeciesPokemon", x => new { x.ElementPokemonsIdentifier, x.SpeciesPokemonsIdentifier });
                    table.ForeignKey(
                        name: "FK_ElementPokemonSpeciesPokemon_ElementPokemon_ElementPokemonsIdentifier",
                        column: x => x.ElementPokemonsIdentifier,
                        principalTable: "ElementPokemon",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementPokemonSpeciesPokemon_SpeciesPokemon_SpeciesPokemonsIdentifier",
                        column: x => x.SpeciesPokemonsIdentifier,
                        principalTable: "SpeciesPokemon",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeciesPokemonIdentifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Pokemon_SpeciesPokemon_SpeciesPokemonIdentifier",
                        column: x => x.SpeciesPokemonIdentifier,
                        principalTable: "SpeciesPokemon",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementPokemonSpeciesPokemon_SpeciesPokemonsIdentifier",
                table: "ElementPokemonSpeciesPokemon",
                column: "SpeciesPokemonsIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_SpeciesPokemonIdentifier",
                table: "Pokemon",
                column: "SpeciesPokemonIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementPokemonSpeciesPokemon");

            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "ElementPokemon");

            migrationBuilder.DropTable(
                name: "SpeciesPokemon");
        }
    }
}
