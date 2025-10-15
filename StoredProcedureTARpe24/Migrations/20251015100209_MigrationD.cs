using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoredProcedureTARpe24.Migrations
{
    /// <inheritdoc />
    public partial class MigrationD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Crimes",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteMonth",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Money",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VacationDays",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Crimes",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "FavoriteMonth",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "VacationDays",
                table: "Departments");
        }
    }
}
