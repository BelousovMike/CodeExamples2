using Microsoft.EntityFrameworkCore.Migrations;

namespace APS.EFDataAccessLibrary.Migrations
{
    public partial class AddedTableTacticsTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TacticsTypes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacticsTypes", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TacticsTypes");
        }
    }
}
