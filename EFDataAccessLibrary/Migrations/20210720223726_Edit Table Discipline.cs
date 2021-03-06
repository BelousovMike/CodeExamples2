using Microsoft.EntityFrameworkCore.Migrations;

namespace APS.EFDataAccessLibrary.Migrations
{
    public partial class EditTableDiscipline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "CharCode",
                table: "Disciplines",
                type: "character(1)",
                nullable: true,
                oldClrType: typeof(char),
                oldType: "character(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "CharCode",
                table: "Disciplines",
                type: "character(1)",
                nullable: false,
                defaultValue: ' ',
                oldClrType: typeof(char),
                oldType: "character(1)",
                oldNullable: true);
        }
    }
}
