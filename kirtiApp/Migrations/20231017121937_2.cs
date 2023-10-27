using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kirtiApp.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Angular",
                table: "employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "C",
                table: "employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cshrap",
                table: "employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Java",
                table: "employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PHP",
                table: "employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Python",
                table: "employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Angular",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "C",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Cshrap",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Java",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "PHP",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Python",
                table: "employees");
        }
    }
}
