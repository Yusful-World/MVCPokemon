using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCPokemon.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedToPokemon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "Colour", "ImageUrl", "Name", "Owner", "Power" },
                values: new object[,]
                {
                    { 1, "orange", "https://www.giantbomb.com/a/uploads/scale_small/0/6087/2437349-pikachu.png", "Pikachu", "Tunji", "Lightening" },
                    { 2, "green", "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891758-001bulbasaur.png", "Balbasaur", "Yusuf", "Water" },
                    { 3, "darkorange", "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891761-004charmander.png", "Charmander", "Glory", "Fire" },
                    { 4, "teal", "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891764-007squirtle.png", "Squirtle", "Oscar", "Stone" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
