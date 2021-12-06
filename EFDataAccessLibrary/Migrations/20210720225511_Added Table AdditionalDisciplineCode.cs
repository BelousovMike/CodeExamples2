using Microsoft.EntityFrameworkCore.Migrations;

namespace APS.EFDataAccessLibrary.Migrations
{
    public partial class AddedTableAdditionalDisciplineCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalDisciplineCodes",
                columns: table => new
                {
                    Code1 = table.Column<string>(type: "text", nullable: false),
                    Code2 = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalDisciplineCodes", x => x.Code1);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalDisciplineCodes");
        }
    }
}
