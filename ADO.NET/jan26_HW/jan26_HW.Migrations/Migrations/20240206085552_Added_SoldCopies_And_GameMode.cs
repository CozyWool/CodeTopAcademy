using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jan26_HW.Migrations
{
    /// <inheritdoc />
    public partial class Added_SoldCopies_And_GameMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mode",
                table: "Game",
                type: "text",
                nullable: false,
                defaultValue: "None");

            migrationBuilder.AddColumn<int>(
                name: "SoldCopies",
                table: "Game",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mode",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "SoldCopies",
                table: "Game");
        }
    }
}
