using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevCodeChallenge.Migrations
{
    /// <inheritdoc />
    public partial class NasaServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NasaExplanation",
                table: "coffeeProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NasaTitle",
                table: "coffeeProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NasaUrl",
                table: "coffeeProducts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NasaExplanation",
                table: "coffeeProducts");

            migrationBuilder.DropColumn(
                name: "NasaTitle",
                table: "coffeeProducts");

            migrationBuilder.DropColumn(
                name: "NasaUrl",
                table: "coffeeProducts");
        }
    }
}
