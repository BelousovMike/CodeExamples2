using Microsoft.EntityFrameworkCore.Migrations;

namespace APS.EFDataAccessLibrary.Migrations
{
    public partial class AddedTableResourcing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resourcing",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resourcing", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resourcing");
        }
    }
}
