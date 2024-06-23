using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreWpf.Migrations
{
    /// <inheritdoc />
    public partial class AddBookFieldPrinting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Printing",
                table: "Book",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Printing",
                table: "Book");
        }
    }
}
