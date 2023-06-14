using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class applicationstate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Application");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationState",
                table: "Application",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationState",
                table: "Application");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Application",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
