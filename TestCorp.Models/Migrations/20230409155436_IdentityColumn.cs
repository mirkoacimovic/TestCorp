using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCorp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class IdentityColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "systemlog");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "company");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "systemlog",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "employee",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "company",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
